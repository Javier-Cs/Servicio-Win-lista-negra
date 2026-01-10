using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkerService1.Data
{
    public class SqlConnectFactory : ISqlConnectFactory
    {
        private readonly string _sqlconnect;

        public SqlConnectFactory(IConfiguration config) {
            _sqlconnect = config.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Falta ConnectionStrings:DefaultConnection");
        }


        public IDbConnection CreateConnection()
            => new SqlConnection(_sqlconnect);
        
    }
}
