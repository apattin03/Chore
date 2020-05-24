using System;
using System.Collections.Generic;
using System.Text;
using NServiceBus;

namespace ChoreMessaging.Commands
{
    [Serializable]
    public class AddCustomChore : IMessage
    {
        public int ChoreId { get; set; }
        public string ChoreName { get; set; }
        public bool Assigned { get; set; }
        public DateTimeOffset ChoreDueDate { get; set; }
    }
}
