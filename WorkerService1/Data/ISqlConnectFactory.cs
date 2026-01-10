using System.Data;

namespace WorkerService1.Data
{
    public interface ISqlConnectFactory
    {
        IDbConnection CreateConnection();
    }
}
