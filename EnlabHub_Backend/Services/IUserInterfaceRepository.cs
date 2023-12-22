using EnlabHub_Backend.Dtos;

namespace EnlabHub_Backend.Services
{
	public interface IUserInterfaceRepository
	{
		Task<List<UserDto>> GetAllUsersAsync();
		Task<string> UpdateUserAsync(string id, UserDto userDto);
		Task<bool> DeleteUserAsync(string userId);

		// Task<UserInfoDto> GetUserStatus(string id);
		Task<UserDto> GetUserByIdAsync(string id);
	}
}
