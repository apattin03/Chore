using System;
using System.ComponentModel.Design;
using System.Reflection;
using System.Threading.Tasks;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using ChoreDataModel.Context;
using ChoreDataModel.Interfaces;
using ChoreDataModel.Model;
using ChoreDataModel.Repositories;
using ChoreServiceBusHost.Interfaces;
using ChoreServiceBusHost.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using NServiceBus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NServiceBus.Extensions.Hosting;



namespace ChoreServiceBusHost
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //var endpointConfiguration = new EndpointConfiguration("Chore");
            //endpointConfiguration.UsePersistence<LearningPersistence>();
            //endpointConfiguration.UseTransport<LearningTransport>();


            //endpointConfiguration.SendFailedMessagesTo("error");
            //endpointConfiguration.EnableInstallers();

            //endpointConfiguration.RegisterComponents(registration: configureComponents =>
            //{
            //    configureComponents.ConfigureComponent<IChoreService>(DependencyLifecycle.InstancePerCall);
            //    configureComponents.RegisterSingleton(typeof(IChoreService), typeof(ChoreService));
            //});

            //var endpointInstance = Endpoint.Start(endpointConfiguration)
            //    .ConfigureAwait(false);

            CreateHostBuilder(args).Build().Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSystemd()
                .ConfigureLogging((context, logging) =>
                {
                    logging.AddConfiguration(context.Configuration.GetSection("Logging"));
                })
                .ConfigureServices((context, services) =>
                {
                    services.AddOptions();
                    services.AddEntityFrameworkSqlServer()
                        .AddDbContext<ChoreContext>((options) =>
                        {
                            options.UseSqlServer(context.Configuration.GetConnectionString("Chore"),
                                c => c.MigrationsAssembly("ChoreServiceBusHost"));
                        });
                    //services.AddSingleton<IChoreRepository<Chore>, ChoreRepository<Chore>>();
                    //services.AddScoped(typeof(IChoreRepository<Partner>), typeof(ChoreRepository<Partner>));
                    //services.AddScoped(typeof(IChoreRepository<ChoreSprint>), typeof(ChoreRepository<ChoreSprint>));
                    services.AddScoped<IChoreService, ChoreService>();



                    services.AddAutoMapper(Assembly.GetAssembly(typeof(Program)));
                    //services.AddHostedService<SBHService>();
                    services.AddHostedService<SBHService>();

                    var container = new ServiceContainer();
                })

                .UseNServiceBus(c =>
                {
                    var endpointConfiguration = new EndpointConfiguration("Chore");
                    endpointConfiguration.UsePersistence<LearningPersistence>();
                    endpointConfiguration.UseTransport<LearningTransport>();


                    endpointConfiguration.SendFailedMessagesTo("error");
                    endpointConfiguration.EnableInstallers();

                    var endpointInstance = Endpoint.Start(endpointConfiguration)
                        .ConfigureAwait(false);

                    Console.WriteLine("Press any key to exit");
                    Console.ReadKey();
                    return endpointConfiguration;
                });

    }
    
}
