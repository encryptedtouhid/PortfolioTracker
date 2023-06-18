using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioTracking.Data.Context
{
   
    public class PTDataContext
    {
        private readonly string _connectionString;
        public PTDataContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("MyDatabase");
        }
        public IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
