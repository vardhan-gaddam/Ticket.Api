using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket.Model.Domain;

namespace Ticket.Domain.Interface
{
    public interface ITicketServices
    {
        public Task<DomainTicket> AddTicket(DomainTicket Ticket);
        public Task<IEnumerable<DomainTicket>> GetTickets();
        public Task<DomainTicket> GetTicket(int ticketId);
        public Task<DomainTicket> EditTicket(int ticketId, DomainTicket contact);
        public Task<DomainTicket> DeleteTicket(int ticketId);
    }
}
