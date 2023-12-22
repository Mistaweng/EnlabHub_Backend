namespace EnlabHub_Backend.Dtos
{
	public class UserInfoDto
	{
		public DateTime? LastOnline { get; set; }
		public bool? IsVerified { get; set; }
		public bool? Active { get; set; }
		public bool IsSelected { get; set; }
		public DateTime EndDate { get; set; }
		public bool IsDeleted { get; set; }
		//public SelectedCandidate SelectedCandidate { get; set; }
	}
}
