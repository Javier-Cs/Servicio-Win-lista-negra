using WorkerService1.Servicio;

namespace WorkerService1
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly ISpamCleanerService _spamCleaner;

        public Worker(ILogger<Worker> logger, ISpamCleanerService spamCleanerService)
        {
            _logger = logger;
            _spamCleaner = spamCleanerService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                //if (_logger.IsEnabled(LogLevel.Information))
                //{
                //    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                //}
                await _spamCleaner.ProcesarCorreosAsync();
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
