namespace EnlabHub_Backend.Dtos
{
	public class ContestantSignupDto
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string? PhoneNumber { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string? ImageUrl { get; set; }
		public string? ValidId { get; set; }
		public string? City { get; set; }

	}
}
