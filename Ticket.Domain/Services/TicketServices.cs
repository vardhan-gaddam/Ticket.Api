using Ticket.Domain.Interface;
using Ticket.Model.Domain;
using Ticket.Repository.Interface;

namespace Ticket.Domain.Services
{
    public class TicketServices : ITicketServices
    {
        private ITicketRepository _TicketRepository;
        public TicketServices(ITicketRepository TicketRepository)
        {
            _TicketRepository = TicketRepository;
        }
        public async Task<IEnumerable<DomainTicket>> GetTickets()
        {
            return await _TicketRepository.GetTickets();
        }
        public async Task<DomainTicket> GetTicket(int ticketId)
        {
            return await _TicketRepository.GetTicket(ticketId);
        }
        public async Task<DomainTicket> AddTicket(DomainTicket Ticket)
        {
            return await _TicketRepository.AddTicket(Ticket);
        }
        public async Task<DomainTicket> EditTicket(int ticketId, DomainTicket Ticket)
        {
            return await _TicketRepository.EditTicket(ticketId, Ticket);
        }
        public async Task<DomainTicket> DeleteTicket(int ticketId)
        {
            return await _TicketRepository.DeleteTicket(ticketId);
        }
    }
}