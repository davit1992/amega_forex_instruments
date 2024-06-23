using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

#nullable disable

namespace Amega.Service.Services.ExternalApi.Models
{
    public class ForexInstrument
    {
        [JsonPropertyName("index")]
        public string Ticker { get; set; }

        [JsonPropertyName("quoteTimestamp")]
        public DateTime QuoteTimestamp { get; set; }

        [JsonPropertyName("bidPrice")]
        public double BidPrice { get; set; }

        [JsonPropertyName("bidSize")]
        public double BidSize { get; set; }

        [JsonPropertyName("askPrice")]
        public double AskPrice { get; set; }

        [JsonPropertyName("askSize")]
        public double AskSize { get; set; }

        [JsonPropertyName("midPrice")]
        public double MidPrice { get; set; }
    }
}
