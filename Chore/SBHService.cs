using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using NServiceBus;
using NServiceBus.ObjectBuilder;


namespace ChoreServiceBusHost
{
    public class SBHService : BackgroundService
    {
        private readonly string ServiceBusName = "Chore";
        private IEndpointInstance _endpoint;
        private readonly IStartableEndpointWithExternallyManagedContainer _startableEndpoint;
        private readonly IBuilder _serviceProvider;

        public SBHService(IStartableEndpointWithExternallyManagedContainer startableEndpoint, IBuilder serviceProvider)
        {
            _startableEndpoint = startableEndpoint;
            _serviceProvider = serviceProvider;
        }
        public override async Task StartAsync(CancellationToken cancellationToken)
        {
            _endpoint = await _startableEndpoint.Start(_serviceProvider);

            Trace.TraceInformation($"{ServiceBusName}ServiceBusHost Started");
            await base.StartAsync(cancellationToken);
        }

        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            if (_endpoint != null)
                await _endpoint.Stop();
            Trace.TraceInformation($"{ServiceBusName}ServiceBusHost Shut down");
            await base.StopAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
