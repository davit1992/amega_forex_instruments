using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

#nullable disable

namespace Amega.Service.DTO.ExternalApi
{
    public class ForexInstrumentDto
    {
        public string Ticker { get; set; }
        public DateTime QuoteTimestamp { get; set; }
        public double BidPrice { get; set; }
        public double BidSize { get; set; }
        public double AskPrice { get; set; }
        public double AskSize { get; set; }
        public double MidPrice { get; set; }
    }
}
