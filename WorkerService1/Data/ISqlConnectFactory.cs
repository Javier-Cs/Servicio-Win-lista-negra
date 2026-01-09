using System.Data;

namespace WorkerService1.Data
{
    internal interface ISqlConnectFactory
    {
        IDbConnection CreateConnection();
    }
}
