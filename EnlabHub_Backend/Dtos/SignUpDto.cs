using EnlabHub_Backend.Enums;

namespace EnlabHub_Backend.Dtos
{
	public class SignUpDto
	{
		public string Firstname { get; set; }
		public string Lastname { get; set; }
		public string PhoneNumber { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string ImageUrl { get; set; }
	}
}
