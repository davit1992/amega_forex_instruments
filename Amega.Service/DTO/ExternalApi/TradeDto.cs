using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable disable

namespace Amega.Service.DTO.ExternalApi
{
    public class TradeDto
    {
        public long Id { get; set; }
        public long FirstId { get; set; }
        public long LastId { get; set; }
        public string EventType { get; set; }
        public DateTime EventTime { get; set; }
        public string Name { get; set;}
        public string Price { get; set;}
        public string Quantity { get; set; }
        public DateTime TradeTime { get; set; }
        public bool IsMarketMakerBuyer { get; set; }
        public bool Ignore { get; set; }
    }
}
