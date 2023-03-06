using Ticket.Model.Domain;

namespace Ticket.Repository.Interface
{
    public interface ITicketRepository
    {
        public Task<DomainTicket> AddTicket(DomainTicket ticket);
        public Task<IEnumerable<DomainTicket>> GetTickets();
        public Task<DomainTicket> GetTicket(int ticketId);
        public Task<DomainTicket> EditTicket(int ticketId, DomainTicket ticket);
        public Task<DomainTicket> DeleteTicket(int ticketId);
    }
}
