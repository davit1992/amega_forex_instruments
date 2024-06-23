using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Amega.Service.Services.ExternalApi.Models
{
    public class ForexInstrumentPrice
    {
        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        [JsonPropertyName("ticker")]
        public string Ticker { get; set; }

        [JsonPropertyName("open")]
        public double Open { get; set; }

        [JsonPropertyName("high")]
        public double High { get; set; }

        [JsonPropertyName("low")]
        public double Low { get; set; }

        [JsonPropertyName("close")]
        public double Close { get; set; }
    }
}
