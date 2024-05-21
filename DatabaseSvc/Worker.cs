using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using DatabaseSvc.Model;

namespace DatabaseSvc
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IServiceProvider _serviceProvider;

        public Worker(ILogger<Worker> logger, IHttpClientFactory httpClientFactory, IConfiguration configuration, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _serviceProvider = serviceProvider;
        }

        /// <summary>
        /// Starts the API retrieval task
        /// </summary>
        /// <param name="stoppingToken">The token that can stop the execution of the async task</param>
        /// <returns></returns>
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                var fetchCooldownMinutes = _configuration.GetValue<int>("ApiSettings:FetchCooldownMinutes");
                using (var scope = _serviceProvider.CreateScope())
                {
                    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                    await FetchAndPersistUsers(dbContext);
                }

                try
                {
                    await Task.Delay((int)TimeSpan.FromMinutes(fetchCooldownMinutes).TotalMilliseconds, stoppingToken);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Could not parse cooldown period - make sure ApiSettings:FetchCooldownMinutes is defined in appsettings.json");
                    break;
                }
            }
        }

        /// <summary>
        /// Method to persist the users in the database
        /// </summary>
        private async Task FetchAndPersistUsers(ApplicationDbContext _context)
        {
            var client = _httpClientFactory.CreateClient();

            try
            {
                var response = await client.GetStringAsync(_configuration["ApiSettings:ApiUrl"]);
                var users = JsonSerializer.Deserialize<List<User>>(response);

                if (users != null)
                {
                    foreach (var user in users)
                    {
                        if(_context.Users.Contains(user))
                            _context.Users.Update(user);
                        else
                            _context.Users.Add(user);
                    }
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching or persisting users");
            }
        }
    }
}