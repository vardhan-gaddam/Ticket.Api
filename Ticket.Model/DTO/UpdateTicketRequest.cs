using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket.Model.DTO
{
	public class UpdateTicketRequest
	{
		public int Number { get; set; }
		public string Name { get; set; }
	}
}
