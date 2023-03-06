using System.ComponentModel.DataAnnotations;

namespace Ticket.Model.Domain
{
    public class DomainTicket
    {
        public int Id { get; set; }
        [Required]
        public int Number { get; set; }
        public string Name { get; set; }
    }
}
