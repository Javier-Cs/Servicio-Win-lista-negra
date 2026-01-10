using WorkerService1.Data;
using WorkerService1.Repositorio;

namespace WorkerService1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = Host.CreateApplicationBuilder(args);
            builder.Services.AddHostedService<Worker>();

            // inyeccion de dependencias 
            builder.Services.AddSingleton<ISqlConnectFactory, SqlConnectFactory>();
            builder.Services.AddScoped<CredencialesRepository>();

            var host = builder.Build();
            host.Run();
        }
    }
}