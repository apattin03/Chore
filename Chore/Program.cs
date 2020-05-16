using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ChoreDataModel.Context;
using ChoreDataModel.Interfaces;
using ChoreDataModel.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NServiceBus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Protocols;

namespace ChoreServiceBusHost
{
    public class Program
    {
        private readonly IConfiguration _configuration;
        public Program(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            await host.StartAsync();

            Console.WriteLine("Press any key to shutdown");
            Console.ReadKey();
            await host.StopAsync();
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSystemd().ConfigureLogging((context, logging) =>
                {
                    logging.AddConfiguration(context.Configuration.GetSection("Logging"));
                })
                .ConfigureServices((context, services) =>
                {
                    services.AddEntityFrameworkSqlServer()
                        .AddDbContext<ChoreContext>((options) =>
                        {
                            options.UseSqlServer(context.Configuration.GetConnectionString("Chore"),c => c.MigrationsAssembly("ChoreServiceBusHost"));

                        });
                    services.AddScoped(typeof(IChoreRepository<>), typeof(ChoreRepository<>));
                })
                .UseNServiceBus(c =>
                {
                    var endpointConfiguration = new EndpointConfiguration("Chore");
                    endpointConfiguration.UseTransport<LearningTransport>();
                    endpointConfiguration.UsePersistence<LearningPersistence>();
                    return endpointConfiguration;
                });

    }
}
