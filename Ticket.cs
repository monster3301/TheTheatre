using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryTheatre
{
    public enum TicketStatus
    {
        OnSale,
        Booked,
        Sold
    }   
    public class Ticket
    {
        public decimal Price { get; private set; }
        public TicketStatus Status { get; set; }
        public DateTime DateTime { get; }
        public Ticket(decimal price, DateTime dateTime)
        {
            Price = price;
            DateTime = dateTime;
        }
    }
}
