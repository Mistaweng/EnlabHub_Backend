using Microsoft.AspNetCore.Identity;

namespace EnlabHub_Backend.Model
{
	public class AppUserRole : IdentityRole<string>
	{
		public Guid Id { get; set; } = Guid.NewGuid();
	}
}
