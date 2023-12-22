using EnlabHub_Backend.Dtos;
using EnlabHub_Backend.Model;
using Microsoft.AspNetCore.Identity;

namespace EnlabHub_Backend.Services
{
	public interface IAuthRepository
	{
		Task<bool> UpdatePasswordAsync(string email, string oldPassword, string newPassword);

		string GenerateJwtToken(AppUser user);
		Task<UserOTP?> FindMatchingValidOTP(string otpFromUser);
		Task<ApiResponse<string>> UpdateVerifiedStatus(string email);


		Task<IdentityResult> CreatePermissionAsync(string name);
		Task<IEnumerable<AppUserPermission>> GetAllPermissionsAsync();
		Task<IEnumerable<AppUserPermission>> GetPermissionsByRoleNameAsync(string roleId);
		Task AssignPermissionToRoleAsync(string roleName, string permissionName);
		Task<IdentityResult> RemovePermissionFromRoleAsync(string roleId, string permissionId);

		Task<string> IsEmailVerifiedAsync(string userId);
		string SendOTPByEmail(string email);
	}
}
