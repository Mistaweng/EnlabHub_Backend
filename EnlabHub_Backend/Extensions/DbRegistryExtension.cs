using EnlabHub_Backend.DbContext;
using Microsoft.AspNetCore.Identity;
using System.Security.Principal;
using System.Text.Json.Serialization;
using System.Text;
using EnlabHub_Backend.Services;
using EnlabHub_Backend.Implementations;
using EnlabHub_Backend.Model;
using Microsoft.EntityFrameworkCore;
using CloudinaryDotNet;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace EnlabHub_Backend.Extensions
{
	public static class DbRegistryExtension
	{
		public static void AddDbContextAndConfigurations(this IServiceCollection services, IConfiguration configuration)
		{

			services.AddDbContextPool<ApplicationDbContext>(options =>
			{
				options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));


			});

			services.AddControllers()
				.AddJsonOptions(options =>
				{
					options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
				});

			var cloudinarySettings = configuration.GetSection("Cloudinary");

			var account = new Account(
				cloudinarySettings["CloudName"],
				cloudinarySettings["ApiKey"],
				cloudinarySettings["ApiSecret"]);

			var cloudinary = new Cloudinary(account);

			services.AddSingleton(cloudinary);



			// Configure JWT authentication options-------------------------------------------
			var jwtSettings = configuration.GetSection("JwtSettings");
			var key = Encoding.ASCII.GetBytes(jwtSettings["Secret"]);
			services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			})
				.AddJwtBearer(options =>
				{
					options.RequireHttpsMetadata = false;
					options.SaveToken = true;
					options.TokenValidationParameters = new TokenValidationParameters
					{
						ValidateIssuerSigningKey = true,
						IssuerSigningKey = new SymmetricSecurityKey(key),
						ValidateIssuer = false,
						ValidateAudience = false
					};
				});

			//Password configuration
			services.Configure<IdentityOptions>(options =>
			{
				options.Password.RequireDigit = true;
				options.Password.RequireLowercase = true;
				options.Password.RequireNonAlphanumeric = true;
				options.Password.RequireUppercase = true;
			});

			// Repo Registration
			services.AddScoped<IAppUserRepository, AppUserRepository>();
			services.AddScoped<IAuthRepository, AuthRepository>();
			services.AddScoped<IFileUploadRepository, FileUploadRepository>();
			services.AddScoped<IUserInterfaceRepository, UserInterfaceRepository>();


			//services.AddScoped<IEmailServices, EmailServices>();

			services.AddScoped<IEmailServices>(provider =>
			{
				var smtpHost = "smtp.gmail.com";
				var smtpPort = 465;
				var smtpUsername = "enlabhub@gmail.com";
				var smtpPassword = "rouawjqxbdhcdhcw";

				return new EmailServices(smtpHost, smtpPort, smtpUsername, smtpPassword);
			});

			//Identity role registration with Stores and default token provider
			services.AddIdentity<AppUser, AppUserRole>()
				.AddEntityFrameworkStores<ApplicationDbContext>()
				.AddDefaultTokenProviders();

			//Connecting frontend

			services.AddCors(options =>
			{
				options.AddPolicy("AllowAllOrigins", builder =>
				{
					builder.WithOrigins("http://localhost:3000", "https://enlabhub-frontend.vercel.app/")
						.AllowAnyHeader()
						.AllowAnyMethod()
						.AllowCredentials()
						.WithExposedHeaders("Authorization");
				});
			});

		}
	}
}
