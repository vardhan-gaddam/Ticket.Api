using Ticket.Model.Domain;
using Ticket.Repository.Interface;

namespace Ticket.Repository.EFTicketRepository
{
	public class StaticUserRepository : IUserRepository
	{
		private List<User> Users = new List<User>()
		{
			new User()
			{
				FirstName = "Read Only", LastName = "User", EmailAddress = "readonly@user.com",
				Id = 1, Username = "readonly@user.com", Password = "Readonly@user",
				Roles = new List<string> { "reader" }
			},
			new User()
			{
				FirstName = "Read Write", LastName = "User", EmailAddress = "readwrite@user.com",
				Id = 2, Username = "readwrite@user.com", Password = "Readwrite@user",
				Roles = new List<string> { "reader", "writer" }
			}
		};



		public async Task<User> Authenticate(string username, string password)
		{
			var user = Users.Find(x => x.Username.Equals(username, StringComparison.InvariantCultureIgnoreCase) &&
			x.Password == password);

			return user;
		}
	}
}
