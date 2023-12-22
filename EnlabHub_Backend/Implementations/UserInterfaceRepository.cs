using EnlabHub_Backend.DbContext;
using EnlabHub_Backend.Dtos;
using EnlabHub_Backend.Services;
using Microsoft.EntityFrameworkCore;

namespace EnlabHub_Backend.Implementations
{
	public class UserInterfaceRepository : IUserInterfaceRepository
	{

		private readonly ApplicationDbContext _db;

		public UserInterfaceRepository(ApplicationDbContext db)
		{
			_db = db;
		}
		public async Task<List<UserDto>> GetAllUsersAsync()
		{
			var users = await _db.Users.ToListAsync();

			return users.Select(user => new UserDto
			{
				Title = user.Title,
				FirstName = user.FirstName,
				LastName = user.LastName,
				PhoneNumber = user.PhoneNumber,
				Email = user.Email,
				ImageUrl = user.ImageUrl,
				ValidId = user.ValidId,
				City = user.City,
				DateOfBirth = user.DateOfBirth,
			}).ToList();
		}
		public async Task<string> UpdateUserAsync(string id, UserDto userDto)
		{
			var user = await _db.Users.FindAsync(id);

			if (user == null)
				return "User not found.";

			user.Title = user.Title;
			user.FirstName = user.FirstName;
			user.LastName = user.LastName;
			user.PhoneNumber = user.PhoneNumber;
			user.Email = user.Email;
			user.ImageUrl = user.ImageUrl;
			user.ValidId = user.ValidId;
			user.City = user.City;
			user.State = user.State;

			try
			{
				await _db.SaveChangesAsync();
				return "User updated successfully.";
			}
			catch (Exception)
			{
				return "User failed to update.";
			}
		}

		public async Task<UserDto> GetUserByIdAsync(string id)
		{
			var user = await _db.Users.FirstOrDefaultAsync(u => u.Id == id);
			if (user == null)
			{
				return null;
			}

			return new UserDto
			{
				Title = user.Title,
				FirstName = user.FirstName,
				LastName = user.LastName,
				PhoneNumber = user.PhoneNumber,
				Email = user.Email,
				ImageUrl = user.ImageUrl,
				ValidId = user.ValidId,
				City = user.City,
				
			
			};
		}
		public async Task<bool> DeleteUserAsync(string userId)
		{
			try
			{
				var user = await _db.Users.FirstOrDefaultAsync(x => x.Id == userId);

				if (user != null)
				{
					_db.Users.Remove(user);
					await _db.SaveChangesAsync();

					return true;
				}
				else
				{
					Console.WriteLine($"User not found with ID: {userId}");
					return false;
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"An error occurred while deleting the user: {ex.Message}");
				return false;
			}
		}


		//get user status
		//public async Task<UserInfoDto> GetUserStatus(string id)
		//{

		//	var getData = await _db.SelectedCandidates.Include(u => u.AppUser).OrderByDescending(o => o.Contestant).FirstOrDefaultAsync(x => x.Id == id);

		//	if (getData == null) return null;

		//	UserInfoDto userInfo = new UserInfoDto
		//	{
		//		LastOnline = getData.AppUser.LastOnline,
		//		IsVerified = getData.AppUser.IsVerified,
		//		Active = getData.AppUser.Active,
		//		IsSelected = getData.IsSelected,
		//		IsDeleted = getData.IsDeleted,
		//	};

		//	return userInfo;

		//}


	}
}
