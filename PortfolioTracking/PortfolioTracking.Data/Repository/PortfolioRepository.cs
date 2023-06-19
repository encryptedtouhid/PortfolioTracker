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
        public List<Portfolio> GetAllPortfolio()
        {
            var query = "select pf.Ticker, ot.OperationName, pf.Qty , pf.Price , pf.Cost , pf.TradeDate from Portfolio pf JOIN OperationType ot on pf.OperationTypeId = ot.OperationID Where pf.TraderId = '10001'";
            var portfolio = ExecuteDapperQuery<Portfolio>(query);
            return portfolio;
        }

        public List<PLReportVM> GetProfitLossReport()
        {
            throw new NotImplementedException();
        }

        public void AddStockUpdateDate(DailyPrice dailyStocks, string shortName, string date)
        {
            var query = @"INSERT INTO [dbo].[Stock] ([Ticker], [Date], [Open], [High], [Low], [Close], [Volume])
                  VALUES (@Ticker, @Date, @Open, @High, @Low, @Close, @Volume)";

            using (var connection = _dataContext.CreateConnection())
            {
                connection.Open();


                var parameters = new
                {
                    Ticker = shortName,
                    Date = date,
                    Open = dailyStocks.Open,
                    High = dailyStocks.High,
                    Low = dailyStocks.Low,
                    Close = dailyStocks.Close,
                    Volume = dailyStocks.Volume
                };

                connection.Execute(query, parameters);

            }
        }


        public List<T> ExecuteDapperQuery<T>(string query)
        {
            using (var connection = _dataContext.CreateConnection())
            {
                connection.Open();

                var result = connection.Query<T>(query);
                return result.ToList();
            }
        }

    }
}
