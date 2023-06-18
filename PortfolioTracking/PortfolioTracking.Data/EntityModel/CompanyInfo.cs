using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioTracking.Data.EntityModel
{
    public class CompanyInfo
    {
        public int Id { get; set; }

        public string CompanyName { get; set; }

        public string Ticker { get; set; }

        public bool? IsActive { get; set; }

    }

}
