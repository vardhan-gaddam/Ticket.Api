using SimpleInjector;
using SimpleInjector.Packaging;
using Ticket.Domain.Interface;
using Ticket.Domain.Services;
using Ticket.Repository.EFRepository;
using Ticket.Repository.Interface;
using Tickets.Repository.EFTicketRepository;

namespace Ticket.Api
{
	public class Registrations : IPackage
	{
		public void RegisterServices(Container container)
		{
			container.Register<ITicketServices, TicketServices>(Lifestyle.Scoped);
			container.Register<ITicketRepository, TicketRepository>(Lifestyle.Scoped);
			container.Register<IUserRepository, StaticUserRepository>(Lifestyle.Singleton);
			container.Register<ITokenHandler, TokenHandler>(Lifestyle.Scoped);
		}
	}
}
