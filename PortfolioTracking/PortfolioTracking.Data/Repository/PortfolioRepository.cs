using Dapper;
using PortfolioTracking.Data.Context;
using PortfolioTracking.Data.EntityModel;
using PortfolioTracking.Data.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioTracking.Data.Repository
{
    public class PortfolioRepository : IPortfolioRepository
    {
        public readonly PTDataContext _dataContext;
        public PortfolioRepository(PTDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<IEnumerable<Portfolio>> GetAllPortfoliobyTraderIdAsync(string TraderId)
        {
            var query = "SELECT * FROM Portfolio WHERE TraderId = @TraderId";
            using (var connection = _dataContext.CreateConnection())
            {
                connection.Open();

                var parameters = new DynamicParameters();
                parameters.Add("@TraderId", TraderId, DbType.Int32);

                var portfolios = await connection.QueryAsync<Portfolio>(query, parameters);
                return portfolios.ToList();
            }
        }


    }
}
