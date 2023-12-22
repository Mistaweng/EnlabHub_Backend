using EnlabHub_Backend.DbContext;
using EnlabHub_Backend.Dtos;
using EnlabHub_Backend.Model;
using EnlabHub_Backend.Services;
using Microsoft.AspNetCore.Identity;
using System.Transactions;

namespace EnlabHub_Backend.Implementations
{
	public class AppUserRepository : IAppUserRepository
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly ApplicationDbContext _dbContext;

		public AppUserRepository(UserManager<AppUser> userManager, ApplicationDbContext dbContext)
		{
			_userManager = userManager;
			_dbContext = dbContext;
		}


		public async Task<ApiResponse> CreateAdmin(AdminSignupDto adminRequest)
		{
			var user = await _userManager.FindByEmailAsync(adminRequest.Email);
			if (user != null) return ApiResponse.Failed("Admin already exist");
			user = new AppUser()
			{

				UserName = adminRequest.Email,
				FirstName = adminRequest.Firstname,
				LastName = adminRequest.Lastname,
				PhoneNumber = adminRequest.PhoneNumber,
				Email = adminRequest.Email,
				Password = adminRequest.Password,
			};

			using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
			{
				var createUser = await _userManager.CreateAsync(user, adminRequest.Password);
				if (!createUser.Succeeded) return ApiResponse.Failed(createUser.Errors);
				var adminDetails = new
				{
					UserName = user.UserName,
					FirstName = user.FirstName,
					LastName = user.LastName,
					PhoneNumber = user.PhoneNumber,
					Email = user.Email,
				};
				transaction.Complete();
				transaction.Complete();
				return ApiResponse.Success(adminDetails);
			}
		}


		public async Task<ApiResponse> CreateVoter(VoterSignupDto voterRequest)
		{
			var voter = await _userManager.FindByEmailAsync(voterRequest.Email);
			if (voter != null) return ApiResponse.Failed("Voter already exist");
			voter = new AppUser()
			{
				UserName = voterRequest.Email,
				FirstName = voterRequest.Firstname,
				LastName = voterRequest.Lastname,
				PhoneNumber = voterRequest.PhoneNumber,
				Email = voterRequest.Email,
				Password = voterRequest.Password,
			};

			using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
			{
				var createVoter = await _userManager.CreateAsync(voter, voterRequest.Password);
				if (!createVoter.Succeeded) return ApiResponse.Failed(createVoter.Errors);
				var voterDetails = new
				{
					UserName = voter.UserName,
					FirstName = voter.FirstName,
					LastName = voter.LastName,
					PhoneNumber = voter.PhoneNumber,
					Email = voter.Email,
				};
				transaction.Complete();
				return ApiResponse.Success(voterDetails);
			}
		}

		public async Task<ApiResponse> CreateContestant(ContestantSignupDto contestantRequest)
		{
			var contestant = await _userManager.FindByEmailAsync(contestantRequest.Email);
			if (contestant != null) return ApiResponse.Failed("Contestant already exist");
			contestant = new AppUser()
			{
				UserName = contestantRequest.Email,
				FirstName = contestantRequest.FirstName,
				LastName = contestantRequest.LastName,
				PhoneNumber = contestantRequest.PhoneNumber,
				Email = contestantRequest.Email,
				City = contestantRequest.City,
				Password = contestantRequest.Password,
				ValidId = contestantRequest.ValidId,
				ImageUrl = contestantRequest.ImageUrl
			};
			using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
			{
				var createContestant = await _userManager.CreateAsync(contestant, contestantRequest.Email);
				if (!createContestant.Succeeded) return ApiResponse.Failed(createContestant.Errors);
				var contestantDetails = new
				{
					UserName = contestant.UserName,
					FirstName = contestant.FirstName,
					LastName = contestant.LastName,
					PhoneNumber = contestant.PhoneNumber,
					Email = contestant.Email,
				};
				transaction.Complete();
				transaction.Complete();
				return ApiResponse.Success(contestantDetails);
			}
		}


		public async Task<AppUser> GetUserById(string userId)
		{
			return await _dbContext.Users.FindAsync(userId);
		}
	}
}
