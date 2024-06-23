using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable disable

namespace Amega.Service.Configuration.Tiingo
{
    public class TradeConfiguration
    {
        public string WssSocketConnection { get; set; }
        public List<string> Streams { get; set; } = new();
        public string ApiUrl { get; set; }
        public string ApiKey { get; set; }
    }
}
