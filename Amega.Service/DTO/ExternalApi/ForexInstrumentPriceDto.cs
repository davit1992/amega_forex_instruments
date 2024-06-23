using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

#nullable disable

namespace Amega.Service.DTO.ExternalApi
{
    public class ForexInstrumentPriceDto
    {
        public DateTime Date { get; set; }
        public string Ticker { get; set; }
        public double Open { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public double Close { get; set; }
    }
}
