using EnlabHub_Backend.Dtos;
using EnlabHub_Backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EnlabHub_Backend.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SignUpController : ControllerBase
	{
		private readonly IAppUserRepository _userRepository;

		public SignUpController(IAppUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		[HttpPost("register-admin")]
		public async Task<IActionResult> CreateUser([FromBody] AdminSignupDto userRequest)
		{
			var res = await _userRepository.CreateAdmin(userRequest);
			if (res.Succeeded) return Ok(res);

			return BadRequest(res);
		}

		[HttpPost("register-voter")]
		public async Task<IActionResult> CreateVoter([FromBody] VoterSignupDto voterRequest)
		{
			var res = await _userRepository.CreateVoter(voterRequest);
			if (res.Succeeded) return Ok(res);

			return BadRequest(res);

		}

		[HttpPost("register-contestant")]
		public async Task<IActionResult> CreateContestant([FromBody] ContestantSignupDto contestantRequest)
		{
			var res = await _userRepository.CreateContestant(contestantRequest);
			if (res.Succeeded) return Ok(res);

			return BadRequest(res);
		}



	}
}
