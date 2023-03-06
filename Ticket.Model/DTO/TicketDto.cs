using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket.Model.DTO
{
    public class TicketDto
    {
		public int Id { get; set; }
		[Required]
		public int Number { get; set; }
		public string Name { get; set; }
	}
}
