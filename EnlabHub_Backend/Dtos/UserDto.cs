using EnlabHub_Backend.Enums;
using System.Reflection;

namespace EnlabHub_Backend.Dtos
{
	public class UserDto
	{
		public string? Title { get; set; }
		public string? FirstName { get; set; }
		public string LastName { get; set; }
		public string? PhoneNumber { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string? ValidId { get; set; }
		public string? ImageUrl { get; set; }
		public string? City { get; set; }
		public string? State { get; set; }
		public Gender? Gender { get; set; }
		public DateTime? DateOfBirth { get; set; }
		public string? Country { get; set; }
		public Position Position { get; set; }

	}
}
