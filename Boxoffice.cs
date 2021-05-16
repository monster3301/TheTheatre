using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryTheatre
{
    public class BoxOffice
    {
        private Dictionary<Performance, List<TicketsController>> AvailablePerfs;
        public BoxOffice()
        {
            AvailablePerfs = new Dictionary<Performance, List<TicketsController>>();
        }
        public void AddTickets(Performance performance, DateTime dateTime, decimal price, int quantityTickets)
        {
            List<Ticket> tickets = new List<Ticket>();
            for (int i = 0; i < quantityTickets; i++)
            {
                tickets.Add(new Ticket(price, dateTime));
            }
            if (AvailablePerfs.ContainsKey(performance))
            {
                AvailablePerfs[performance].Add(new TicketsController(tickets, dateTime));
            }
            else
            {
                List<TicketsController> temp = new List<TicketsController>();
                temp.Add(new TicketsController(tickets, dateTime));
                AvailablePerfs.Add(performance, temp);
            }
        }
        //public void DeleteTickets(Performance performance, DateTime dateTime)
        //{
        //    foreach (TicketsController ticketsController in AvailablePerfs[performance])
        //    {
        //        if (ticketsController.DateTime == dateTime)
        //        {
        //            AvailablePerfs.Remove(performance);
        //        }
        //    }
        //}
        public bool BuyTicket(Performance performance, DateTime dateTime)
        {
            if (AvailablePerfs.ContainsKey(performance))
            {
                List<TicketsController> ticketsControllers = AvailablePerfs[performance];
                TicketsController ticketsController = ticketsControllers.Find(tickController => tickController.DateTime == dateTime);
                foreach (Ticket ticket in ticketsController.Tickets)
                {
                    if (ticket.Status == TicketStatus.OnSale)
                    {
                        ticket.Status = TicketStatus.Sold;                        
                        return true;
                    }
                }
            }
            return false;
        }
        public bool BookTicket(Performance performance, DateTime dateTime)
        {
            if (AvailablePerfs.ContainsKey(performance))
            {
                List<TicketsController> ticketsControllers = AvailablePerfs[performance];
                TicketsController ticketsController = ticketsControllers.Find(tickController => tickController.DateTime == dateTime);
                foreach (Ticket ticket in ticketsController.Tickets)
                {
                    if (ticket.Status == TicketStatus.OnSale)
                    {
                        ticket.Status = TicketStatus.Booked;
                        return true;
                    }
                }
            }
            return false;
        }
        public List<DateTime> GetTimes(Performance performance)
        {
            List<DateTime> times = new List<DateTime>();
            foreach (TicketsController ticketsController in AvailablePerfs[performance])
            {
                times.Add(ticketsController.DateTime);
            }
            return times;
        }
        public List<Performance> Performances()
        {
            List<Performance> performances = new List<Performance>();
            foreach (Performance performance in AvailablePerfs.Keys)
            {
                performances.Add(performance);
            }
            return performances;
        }
    }
}
