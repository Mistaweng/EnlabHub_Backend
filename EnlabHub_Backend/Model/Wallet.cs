namespace EnlabHub_Backend.Model
{
	public class Wallet : BaseEntity
	{
		public string AppUserId { get; set; }
		public AppUser AppUser { get; set; }
		public decimal Balance { get; set; }
	}
}
