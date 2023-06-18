using PortfolioTracking.Data.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioTracking.Data.IRepository
{
    public interface IPortfolioRepository
    {
        List<Portfolio> GetAllPortfolio();
    }
}
