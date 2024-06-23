using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amega.Service.IServicies.SignalR
{
    public interface IMessagingService
    {
        /// <summary>
        /// Send message to all
        /// </summary>
        /// <param name="method"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        Task SendToAllAsync(string method, params object[] args);

        /// <summary>
        /// Send message to groups
        /// </summary>
        /// <param name="groupIds"></param>
        /// <param name="method"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        Task SendToGroupsAsync(IEnumerable<string> groupIds, string method, params object[] args);
    }
}
