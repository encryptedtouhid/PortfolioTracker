using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioTracking.Data.EntityModel
{
    public class Trader
    {
        public int Id { get; set; }

        public string TraderName { get; set; }

        public string TraderEmail { get; set; }

        public int? TraderUniqueID { get; set; }

        public string TraderPhone { get; set; }

    }
}
