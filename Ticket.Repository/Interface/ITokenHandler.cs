using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket.Model.Domain;

namespace Ticket.Repository.Interface
{
	public interface ITokenHandler
	{
		Task<string> CreateToken(User user);
	}
}
