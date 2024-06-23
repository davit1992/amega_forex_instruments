using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amega.Service.Services.ExternalApi.Models
{
    public class AggTradeStream
    {
        public string stream { get; set; }
        public AggTradeData data { get; set; }
    }
}
