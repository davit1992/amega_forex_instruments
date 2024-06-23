using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Amega.Service.Services.SignalR
{
    public class UserHub : Hub
    {
        /// <summary>
        /// OnConnectedAsync
        /// </summary>
        /// <returns></returns>
        public override async Task OnConnectedAsync()
        {
            await Groups.AddToGroupAsync(this.Context.ConnectionId, $"users_group", Context.ConnectionAborted);
            await Clients.Caller.SendCoreAsync("OnConnected", new[] { $"Connected,connectionId:{Context.ConnectionId}" });
            await base.OnConnectedAsync();
        }

        /// <summary>
        /// OnDisconnectedAsync
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            await Clients.Caller.SendCoreAsync("OnDisconnected", new[] { $"Disconnected,connectionId:{Context.ConnectionId}" });
            Console.WriteLine($"OnDisconnected {exception?.Message ?? "..."}");
            await base.OnDisconnectedAsync(exception);
        }
    }
}
