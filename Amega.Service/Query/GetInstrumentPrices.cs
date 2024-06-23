using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amega.Service.Query
{
    public class GetInstrumentPrices
    {
        public string Ticker { get; set; } = string.Empty;
        public string startDate { get; set; } = string.Empty;
        public string endDate { get; set; } = string.Empty;
        public string resampleFreq { get; set; } = string.Empty;
    }
}
