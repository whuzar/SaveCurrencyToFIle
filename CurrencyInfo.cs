using System.Collections.Generic;

namespace ConConfig
{
    internal class CurrencyInfo
    {
        public string Table { get; set; }
        public string Currency { get; set; }
        public string Code { get; set; }
        public List<CurrencyRateInfo> Rates { get; set; }
    }
}