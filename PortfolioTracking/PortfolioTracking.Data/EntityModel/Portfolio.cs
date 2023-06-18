using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioTracking.Data.EntityModel
{
    public class Portfolio
    {
        public int Id { get; set; }

        public string Ticker { get; set; }

        public int? OperationTypeId { get; set; }

        public DateTime? TradeDate { get; set; }

        public int? Qty { get; set; }

        public decimal? Price { get; set; }

        public decimal? Cost { get; set; }

        public string TraderId { get; set; }

    }

}
