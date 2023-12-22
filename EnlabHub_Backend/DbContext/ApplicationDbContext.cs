using EnlabHub_Backend.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using System.Transactions;

namespace EnlabHub_Backend.DbContext
{
	public class ApplicationDbContext : IdentityDbContext<AppUser>
	{

		public DbSet<AppUser> AppUsers { get; set; }
		public DbSet<AppUserRole> AppUserRoles { get; set; }
		//public DbSet<Transaction> Transactions { get; set; }
		public DbSet<AppUserPermission> Permissions { get; set; }
		public DbSet<FileUploadModel> UploadedFiles { get; set; }
		public DbSet<UserOTP> userOTPs { get; set; }



		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
		}


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);


		}
	}
}
