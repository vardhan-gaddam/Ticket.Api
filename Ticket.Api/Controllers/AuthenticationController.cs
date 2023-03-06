using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Ticket.Model.DTO;
using Ticket.Repository.Interface;

namespace Ticket.Api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class AuthenticationController : Controller
	{
		private readonly IUserRepository _userRepository;
		private readonly ITokenHandler _tokenHandler;

		public AuthenticationController(IUserRepository userRepository, ITokenHandler tokenHandler)
		{
			_userRepository = userRepository;
			_tokenHandler = tokenHandler;
		}

		[HttpPost]
		[Route("login")]
		public async Task<IActionResult> Login(LoginRequest loginRequest)
		{
			// Check if user is authenticated
			// Check username and password
			var user = await _userRepository.Authenticate(
				loginRequest.Username, loginRequest.Password);

			if (user != null)
			{
				// Generate a JWT Token
				var token = await _tokenHandler.CreateToken(user);
				return Ok(token);
			}

			return BadRequest("Username or Password is incorrect.");
		}
	}
}
