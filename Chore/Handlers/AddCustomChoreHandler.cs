using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ChoreMessaging.Commands;
using NServiceBus;
using NServiceBus.Logging;

namespace ChoreServiceBusHost.Handlers
{
    public class AddCustomChoreHandler : IHandleMessages<AddCustomChore>
    {
        private static ILog log = LogManager.GetLogger<AddCustomChoreHandler>();
        public Task Handle(AddCustomChore message, IMessageHandlerContext context)
        {
            log.Info($"Added custom chore for ChoreID{message.ChoreId} with a due date of {message.ChoreDueDate}" );

            return Task.CompletedTask;
        }
    }
}
