using Amega.Service.Configuration.Tiingo;
using Amega.Service.DTO.ExternalApi;
using Amega.Service.IServicies.ExternalApi;
using Amega.Service.IServicies.SignalR;
using Amega.Service.Services.ExternalApi.Models;
using AutoMapper;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Amega.Service.Services.ExternalApi
{
    public class TradeWsConnection : ITradeWsConnection
    {
        private readonly TradeConfiguration _tiingoConfiguration;
        private readonly IMapper _mapper;
        private readonly IMessagingService _messagingService;
        public TradeWsConnection(TradeConfiguration tiingoConfiguration, IMapper mapper, IMessagingService messagingService)
        {
            _tiingoConfiguration = tiingoConfiguration;
            _mapper = mapper;
            _messagingService = messagingService;
        }

        public async Task ConnectSocketAsync()
        {
            var subscribe = new
            {
                method = "SUBSCRIBE",
                @params = _tiingoConfiguration.Streams,
                id = 5
            };
            using (ClientWebSocket ws = new ClientWebSocket())
            {
                var url = $"{_tiingoConfiguration.WssSocketConnection}?streams={string.Join("/", _tiingoConfiguration.Streams)}";
                Uri serverUri = new Uri(url);
                await ws.ConnectAsync(serverUri, CancellationToken.None);

                var subscribeMessage = JObject.FromObject(subscribe).ToString();
                var bytesToSend = new ArraySegment<byte>(Encoding.UTF8.GetBytes(subscribeMessage));
                await ws.SendAsync(bytesToSend, WebSocketMessageType.Text, true, CancellationToken.None);
                Console.WriteLine("Subscription message sent");

                var buffer = new byte[1024 * 4];
                try
                {
                    while (ws.State == WebSocketState.Open)
                    {
                        var result = await ws.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                        if (result.MessageType == WebSocketMessageType.Close)
                        {
                            await ws.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, CancellationToken.None);
                            Console.WriteLine("Connection closed");
                        }
                        else
                        {
                            var message = JsonSerializer.Deserialize<AggTradeStream>(Encoding.UTF8.GetString(buffer, 0, result.Count));
                            if (message!=null && message.data != null)
                            {
                                var dto = _mapper.Map<TradeDto>(message.data);
                                //in the frontend (use react Js or something) subscribe to the TradeMessage method and get the data, the data will flow for all connected users
                                await _messagingService.SendToAllAsync("TradeMessage", dto);
                                Console.WriteLine("Message received: " + dto);
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
            }
        }
    }
}
