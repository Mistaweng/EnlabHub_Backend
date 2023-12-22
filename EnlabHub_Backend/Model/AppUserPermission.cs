namespace EnlabHub_Backend.Model
{
	public class AppUserPermission
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		public string Name { get; set; }
	}
}
