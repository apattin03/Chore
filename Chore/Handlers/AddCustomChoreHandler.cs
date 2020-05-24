using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ChoreMessaging.Commands;
using ChoreServiceBusHost.Interfaces;
using ChoreServiceBusHost.Services;
using NServiceBus;
using NServiceBus.Logging;

namespace ChoreServiceBusHost.Handlers
{
    public class AddCustomChoreHandler : IHandleMessages<AddCustomChore>
    {
        private readonly IChoreService _choreService;

        //private static ILog _log = LogManager.GetLogger<AddCustomChoreHandler>();

        public AddCustomChoreHandler(IChoreService choreService)
        {
            _choreService = choreService;
            //_log = log;
        }
        public Task Handle(AddCustomChore message, IMessageHandlerContext context)
        {
            //_log.Info($"Added custom chore for ChoreID{message.ChoreId} with a due date of {message.ChoreDueDate}" );

            var results = _choreService.AddCustomChoreAndDontAssign(message.ChoreId, message.ChoreName, message.Assigned);

            return Task.CompletedTask;
        }
    }
}
