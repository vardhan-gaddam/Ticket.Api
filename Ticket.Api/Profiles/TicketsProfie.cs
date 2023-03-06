using AutoMapper;
using Ticket.Model.Domain;
using Ticket.Model.DTO;

namespace Ticket.Api.Profiles
{
	public class TicketsProfie : Profile
	{
		public TicketsProfie()
		{
			CreateMap<DomainTicket, TicketDto>()
				.ReverseMap();
			CreateMap<UpdateTicketRequest, DomainTicket>();
			CreateMap<AddTicketRequest, DomainTicket>();
		}
	}
}
