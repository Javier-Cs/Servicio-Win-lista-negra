using WorkerService1.Data;
using WorkerService1.Repositorio;
using WorkerService1.Servicio;

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
            builder.Services.AddSingleton<IEmailCleaner>();

            var host = builder.Build();
            host.Run();
        }
    }
}