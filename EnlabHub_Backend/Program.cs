using EnlabHub_Backend.Extensions;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContextAndConfigurations(builder.Configuration);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
	c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
	{
		Title = "Enlab_Voting.Api",
		Version = "v1",
		Description = "Enlab Voting Backend APIs",

	});
	// To Enable authorization using Swagger (JWT)
	c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme()
	{
		Name = "Authorization",
		Type = SecuritySchemeType.ApiKey,
		Scheme = "Bearer",
		BearerFormat = "JWT",
		In = ParameterLocation.Header,
		Description =
			"JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer eyJhbGciOiJIUzI1NiIsI\"",
	});
	c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
	{
		{
			new Microsoft.OpenApi.Models.OpenApiSecurityScheme
			{
				Reference = new OpenApiReference
				{
					Type = ReferenceType.SecurityScheme,
					Id = "Bearer"
				}
			},
			new string[] { }
		}
	});
});

//Connecting frontend


builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowAllOrigins", builder =>
	{
		builder.WithOrigins("https://enlabhub-frontend.vercel.app/",
				"http://localhost:3000")
			.AllowAnyHeader()
			.AllowAnyMethod()
			.AllowCredentials();
	});
});



//builder.Services.AddCors(options =>
//{
//	//var frontendURL = provider.GetValue<string>("frontendURL");

//	options.AddPolicy("AllowedHosts",
//		builder =>
//		{
//			builder.WithOrigins().AllowAnyOrigin()
//				.AllowAnyHeader()
//				.AllowAnyMethod();
//		});
//});
//builder.Services.AddCors(options =>
//{
//	options.AddDefaultPolicy(builder =>
//	{
//		builder.AllowAnyOrigin()
//			   .AllowAnyMethod()
//			   .AllowAnyHeader()
//			   .WithExposedHeaders("Authorization"); // Expose the Authorization header
//	});
//});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
	app.UseDeveloperExceptionPage();
	app.UseSwagger();
	app.UseSwaggerUI(c =>
	{
		c.SwaggerEndpoint("/swagger/v1/swagger.json", "Enlap-v1");
		c.RoutePrefix = "swagger";
	});
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
