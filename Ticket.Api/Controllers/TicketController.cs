using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ticket.Domain.Interface;
using Ticket.Model.Domain;
using Ticket.Model.DTO;

namespace Ticket.Api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class TicketController : ControllerBase
	{
		private ITicketServices _ticketServices;
		private readonly IMapper _mapper;
		public TicketController(ITicketServices ticketServices, IMapper mapper)
		{
			_ticketServices = ticketServices;
			_mapper = mapper;
		}
		[HttpGet]
		[Authorize(Roles = "reader")]
		public async Task<IActionResult> GetTickets()
		{
			var tickets = await _ticketServices.GetTickets();
			return Ok(_mapper.Map<List<TicketDto>>(tickets));
		}
		[HttpGet("{ticketId}")]
		[Authorize(Roles = "reader")]
		public async Task<IActionResult> GetTicket([FromRoute] int ticketId)
		{
			var ticket = await _ticketServices.GetTicket(ticketId);
			if (ticket == null) { return NotFound("Ticket Not Found For the given ticketId"); }
			return Ok(_mapper.Map<TicketDto>(ticket));
		}
		[HttpPost]
		[Authorize(Roles = "writer")]
		public async Task<IActionResult> AddTicket(AddTicketRequest addTicketRequest)
		{

			//DTO TO Domain Model
			var ticket = _mapper.Map<DomainTicket>(addTicketRequest);

			//Model to Repo
			ticket = await _ticketServices.AddTicket(ticket);

			//convert back to DTO`
			return Ok(_mapper.Map<TicketDto>(ticket));
		}
		[HttpDelete("{ticketId}")]
		[Authorize(Roles = "writer")]
		public async Task<IActionResult> DeleteTicket(int ticketId)
		{
			var deletedTicket = await _ticketServices.DeleteTicket(ticketId);
			if (deletedTicket == null) { return NotFound("Ticket Not Found to Delete"); }

			return Ok(_mapper.Map<TicketDto>(deletedTicket));
		}

		[HttpPut("{ticketId}")]
		[Authorize(Roles = "writer")]
		public async Task<IActionResult> EditTicket(int ticketId, [FromBody] UpdateTicketRequest updateTicketRequest)
		{
			var ticket = _mapper.Map<DomainTicket>(updateTicketRequest);
			ticket = await _ticketServices.EditTicket(ticketId, ticket);
			if (ticket == null) { return NotFound("Ticket Not Found to Edit"); }
			var ticketDto = _mapper.Map<TicketDto>(ticket);
			return Ok(ticketDto);
		}
	}
}