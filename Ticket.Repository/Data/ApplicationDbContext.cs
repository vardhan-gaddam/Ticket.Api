using Microsoft.EntityFrameworkCore;
using Ticket.Model.Domain;

namespace Ticket.Repository.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
		}
		public DbSet<DomainTicket> Tickets { get; set; }
	}
}
