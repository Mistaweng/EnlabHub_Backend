using EnlabHub_Backend.Dtos;
using EnlabHub_Backend.Model;

namespace EnlabHub_Backend.Services
{
	public interface IAppUserRepository
	{
		Task<ApiResponse> CreateAdmin(AdminSignupDto userRequest);
		Task<ApiResponse> CreateVoter(VoterSignupDto voterRequest);
		Task<ApiResponse> CreateContestant(ContestantSignupDto contestantRequest);
		Task<AppUser> GetUserById(string userId);
	}
}
