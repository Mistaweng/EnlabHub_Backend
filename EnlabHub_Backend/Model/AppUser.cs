using Microsoft.AspNetCore.Identity;
using System.Reflection;
using System.Transactions;

namespace EnlabHub_Backend.Model
{
	public class AppUser : IdentityUser
	{
		public string? Title { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string? PhoneNumber { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string? ImageUrl { get; set; }
		public string? ValidId { get; set; }
		public string? City { get; set; }
		public string? State { get; set; }
		public DateTime? DateOfBirth { get; set; }
		public string? Country { get; set; }
		public bool? IsLockedOut { get; set; }
		public DateTime? LastOnline { get; set; }
		public bool? IsVerified { get; set; }
		public bool? IsArchived { get; set; }
		public bool? Active { get; set; }
		public string? VoterCode { get; set; }
		public DateTime? Timeleft { get; set; }
		public Wallet? Wallet { get; set; }
		public ICollection<Transaction> Transactions { get; set; }
	}

}
