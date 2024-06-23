using Amega.Service.Configuration.Tiingo;
using Amega.Service.DTO.ExternalApi;
using Amega.Service.IServicies.ExternalApi;
using Amega.Service.Query;
using Amega.Service.Services.ExternalApi.Models;
using AutoMapper;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Amega.Service.Services.ExternalApi
{
    public class TradeService : ITradeService
    {
        private readonly TradeConfiguration _tradeConfiguration;
        private readonly IMapper _mapper;
        public TradeService(TradeConfiguration tradeConfiguration, IMapper mapper)
        {
            _tradeConfiguration = tradeConfiguration;
            _mapper = mapper;
        }

        public async Task<List<ForexInstrumentDto>> GetAvailableInstumentsAsync(GetInstruments query)
        {
            string url = $"{_tradeConfiguration.ApiUrl}/top?tickers={string.Join(",",query.Tickers)}";

            List<ForexInstrumentDto> dto = new List<ForexInstrumentDto>();

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", _tradeConfiguration.ApiKey);

                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                var instruments = JsonSerializer.Deserialize<List<ForexInstrument>>(responseBody);

                //we use dto because sometimes we should not return all properties from serialized data to frontend part
                dto = _mapper.Map<List<ForexInstrumentDto>>(instruments);
            }
            return dto;
        }

        public async Task<List<ForexInstrumentPriceDto>> GetInstrumentPricesAsync(GetInstrumentPrices query)
        {
            string url = $"{_tradeConfiguration.ApiUrl}/{query.Ticker}/prices?startDate={query.startDate}&endDate={query.endDate}&resampleFreq={query.resampleFreq}";
            List<ForexInstrumentPriceDto> dto = new List<ForexInstrumentPriceDto>();
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", _tradeConfiguration.ApiKey);

                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                var instruments = JsonSerializer.Deserialize<List<ForexInstrumentPrice>>(responseBody);

                //we use dto because sometimes we should not return all properties from serialized data to frontend part
                dto = _mapper.Map<List<ForexInstrumentPriceDto>>(instruments);
            }
            return dto;
        }
    }
}
