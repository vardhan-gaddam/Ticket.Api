﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket.Model.Domain
{
	public class User
	{
		public int Id { get; set; }
		public string Username { get; set; }
		public string EmailAddress { get; set; }
		public string Password { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		//[NotMapped]
		public List<string> Roles { get; set; }

		//// Navigation property
		//public List<User_Role> UserRoles { get; set; }
	}
}
