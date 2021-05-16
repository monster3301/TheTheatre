using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryTheatre
{
    public class TicketsController
    {
        public List<Ticket> Tickets { get; }
        public DateTime DateTime { get; }
        public TicketsController(List<Ticket> tickets, DateTime dateTime)
        {
            Tickets = tickets;
            DateTime = dateTime;
        }
    }
}
    