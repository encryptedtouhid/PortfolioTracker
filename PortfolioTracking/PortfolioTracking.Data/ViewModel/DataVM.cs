using PortfolioTracking.Data.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioTracking.Data.ViewModel
{
    public class DataVM
    {
        public List<PLReportVM> PLReportList { get; set; }
        public List<Portfolio> PortfolioList { get; set; }
    }
}
