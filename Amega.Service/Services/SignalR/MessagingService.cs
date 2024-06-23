using Amega.Service.IServicies.SignalR;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amega.Service.Services.SignalR
{
    public class MessagingService : IMessagingService
    {
        private readonly IHubContext<UserHub> userHub;

        /// <summary>
        /// Constructor
        /// </summary>
        public MessagingService(IHubContext<UserHub> userHub)
        {
            this.userHub = userHub;
        }

        /// <summary>
        /// Send to all
        /// </summary>
        /// <param name="method"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task SendToAllAsync(string method, params object[] args)
        {
            return userHub.Clients.All.SendCoreAsync(method, args);
        }
        /// <summary>
        /// Send to groups
        /// </summary>
        /// <param name="groupIds"></param>
        /// <param name="method"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task SendToGroupsAsync(IEnumerable<string> groupIds, string method, params object[] args)
        {
            await userHub.Clients.Groups((IReadOnlyList<string>)groupIds.Select(x => x.ToString())).SendCoreAsync(method, args);
        }
    }
}
