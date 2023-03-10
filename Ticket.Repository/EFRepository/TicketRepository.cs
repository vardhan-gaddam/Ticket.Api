using Microsoft.EntityFrameworkCore;
using Ticket.Repository.Data;
using Ticket.Model.Domain;
using Ticket.Repository.Interface;

namespace Tickets.Repository.EFTicketRepository
{
    public class TicketRepository : ITicketRepository
	{
		private ApplicationDbContext _context;

		public TicketRepository(ApplicationDbContext context)
		{
			_context = context;
		}
		public async Task<IEnumerable<DomainTicket>> GetTickets()
		{
			return await _context.Tickets.ToListAsync();
		}
		public async Task<DomainTicket> GetTicket(int ticketId)	
		{
			var existingTicket = await _context.Tickets.FindAsync(ticketId);
			if (existingTicket == null) { return null; }
			return existingTicket;
		}
		public async Task<DomainTicket> AddTicket(DomainTicket ticket)
		{
			await _context.Tickets.AddAsync(ticket);
			await _context.SaveChangesAsync();
			return ticket;
		}
		public async Task<DomainTicket> EditTicket(int ticketId, DomainTicket ticket)
		{
			var existingTicket = _context.Tickets.FirstOrDefault(u => u.Id == ticketId);
			if (existingTicket == null) { return null; }

			existingTicket.Number = ticket.Number;
			existingTicket.Name= ticket.Name;

			_context.SaveChanges();
			return existingTicket;
		}
		public async Task<DomainTicket> DeleteTicket(int ticketId)
		{
			var existingTicket = _context.Tickets.FirstOrDefault(u => u.Id == ticketId);
			if (existingTicket == null) { return null; }
			_context.Tickets.Remove(existingTicket);
			await _context.SaveChangesAsync();
			return existingTicket;
		}
	}
}
