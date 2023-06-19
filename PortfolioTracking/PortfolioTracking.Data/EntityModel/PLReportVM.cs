using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioTracking.Data.EntityModel
{
    public class PLReportVM
    {
        public string Ticker { get; set; }
        public string TradeDate { get; set; }
        public string Qty { get; set; }
        public string Price { get; set; }
        public string Cost { get; set; }
        public string CurrentClose { get; set; }
        public string MarketValue { get; set; }
        public string PrevClose { get; set; }
        public string DailyPL { get; set; }
        public string InceptionPL { get; set; }

    }
}
