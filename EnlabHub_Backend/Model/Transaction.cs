namespace EnlabHub_Backend.Model
{
	public class Transaction : BaseEntity
	{
		public DateTime Date { get; set; }
		public string Description { get; set; }
		public decimal PaymentAmount { get; set; }
		public bool IsSuccessful { get; set; }
		public string Reference { get; set; }
		public string IpAddress { get; set; }
		public string Currency { get; set; }
		public string Vendor { get; set; }
		public string AppUserId { get; set; }
		public AppUser AppUser { get; set; }
	}
}
