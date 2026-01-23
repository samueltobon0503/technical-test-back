using CleanArch.Application.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CleanArch.External.BackgroundServices
{
    public class OverdueTaskWorker : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<OverdueTaskWorker> _logger;

        public OverdueTaskWorker(
            IServiceProvider serviceProvider,
            ILogger<OverdueTaskWorker> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("El proceso de verificación de tareas vencidas ha comenzado.");

            using PeriodicTimer timer = new(TimeSpan.FromMinutes(2));

            try
            {
                while (await timer.WaitForNextTickAsync(stoppingToken))
                {
                    _logger.LogInformation("Revisando tareas vencidas el: {time}", DateTimeOffset.Now);
                    await CheckOverdueTasks();
                }
            }
            catch (OperationCanceledException)
            {
                _logger.LogInformation("El proceso de verificación de tareas vencidas se está deteniendo.");
            }
        }

        private async Task CheckOverdueTasks()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var dataBaseService = scope.ServiceProvider.GetRequiredService<IDataBaseService>();
                var now = DateTime.UtcNow;

                var overdueTasks = await dataBaseService.WorkTasks
                    .Where(t => t.Status == 0 && t.DueDate < now)
                    .ToListAsync();

                if (overdueTasks.Any())
                {
                    foreach (var task in overdueTasks)
                    {
                        _logger.LogWarning("ALERT: Tarea '{Title}' Con ID: {Id} vencida. Enviando correos a soporte...",
                            task.Title, task.Id);
                    }
                }
                else
                {
                    _logger.LogInformation("No se encontraron tareas vencidas.");
                }
            }
        }
    }
}