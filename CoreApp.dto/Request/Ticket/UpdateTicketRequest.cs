using System;
using System.Collections.Generic;
using System.Text;

namespace CoreApp.dto.Request.Ticket
{
    public class UpdateTicketRequest: CreateTicketRequest
    {
        public long TicketId { get; set; }
    }
}
