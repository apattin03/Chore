using System;
using Microsoft.AspNetCore.Hosting;
using System.Threading.Tasks;
using Autofac.Extensions.DependencyInjection;
using AutoMapper.Configuration;
using ChoreDataModel.Context;
using ChoreDataModel.Interfaces;
using ChoreDataModel.Repositories;
using ChoreServiceBusHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NServiceBus;

namespace Chore
{
    public class Program
    {

        private IConfiguration Configuration { get; }

        public Program(IConfiguration configuration)
        {
            Configuration = configuration;
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
                .ConfigureServices(services =>
                {
                    services.AddEntityFrameworkSqlServer()
                        .AddDbContext<ChoreContext>((options) =>
                        {
                            services.AddDbContext<ChoreContext>(options =>
                                options.UseSqlServer(("AnimeListAppContext")));
                            services.AddScoped(typeof(IChoreRepository<>), typeof(ChoreRepository<>)); ;
                        });
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

