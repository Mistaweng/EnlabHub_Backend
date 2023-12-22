namespace EnlabHub_Backend.Model
{
	public class FileUploadModel : BaseEntity
	{
		//public string Id { get; set; }
		public string? ImageName { get; set; }
		public byte[]? ImageData { get; set; }
		public string CloudinaryPublicId { get; set; } = string.Empty;
		public string CloudinaryUrl { get; set; } = string.Empty;
	}
}
