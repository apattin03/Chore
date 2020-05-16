using System;
using System.Collections.Generic;
using System.Text;

namespace ChoreMessaging.Commands
{
    public class SendRequestForChoreTrade
    {
        public int ChoreId { get; set; }
        public int InitiatorPartnerId { get; set; }
        public int ReceivingRequestPartnerId { get; set; }
    }
}
