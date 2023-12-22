using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using EnlabHub_Backend.DbContext;
using EnlabHub_Backend.Model;
using EnlabHub_Backend.Services;

namespace EnlabHub_Backend.Implementations
{
	public class FileUploadRepository : IFileUploadRepository
	{
		private readonly Cloudinary _cloudinary;
		private readonly ApplicationDbContext _db;

		public FileUploadRepository(Cloudinary cloudinary, ApplicationDbContext palmfitDb)
		{
			_cloudinary = cloudinary;
			_db = palmfitDb;
		}

		public async Task<string> UploadImageToCloudinaryAndSave(IFormFile file)
		{
			if (file == null || file.Length == 0)
			{
				return "Invalid file data.";
			}

			const int maxFileSizeInBytes = 300 * 1024;
			if (file.Length > maxFileSizeInBytes)
			{
				return "File size exceeds the maximum limit (300KB).";
			}


			var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };
			var fileExtension = Path.GetExtension(file.FileName).ToLowerInvariant();
			if (!allowedExtensions.Contains(fileExtension))
			{
				return "Only jpg and png files are allowed.";
			}

			//save file or image to cloudinary
			var uploadParams = new ImageUploadParams
			{
				File = new FileDescription(file.FileName, file.OpenReadStream())
			};

			var uploadResult = await _cloudinary.UploadAsync(uploadParams);

			if (uploadResult.Error != null)
			{
				return "Error uploading image to Cloudinary.";
			}

			// Save Cloudinary URL or public ID to the database
			var fileUploadModel = new FileUploadModel
			{
				Id = Guid.NewGuid().ToString(),
				ImageName = file.FileName,
				CloudinaryPublicId = uploadResult.PublicId,
				CloudinaryUrl = uploadResult.Uri.ToString()
			};

			_db.UploadedFiles.Add(fileUploadModel);
			_db.SaveChanges();

			return "File uploaded and saved successfully!";
		}
	}
}
