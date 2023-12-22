namespace EnlabHub_Backend.Services
{
	public interface IFileUploadRepository
	{
		Task<string> UploadImageToCloudinaryAndSave(IFormFile file);
	}
}
