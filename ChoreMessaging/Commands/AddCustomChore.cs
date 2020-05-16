using System;
using System.Collections.Generic;
using System.Text;

namespace ChoreMessaging.Commands
{
    public class AddCustomChore
    {
        public int ChoreId { get; set; }
        public string ChoreName { get; set; }
        public DateTimeOffset ChoreDueDate { get; set; }
    }
}
