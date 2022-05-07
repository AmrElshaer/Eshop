using IdentityServer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityServer.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
       : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            string ADMIN_ID = "02174cf0–9412–4cfe-afbf-59f706d72cf6";


            var appUser = new ApplicationUser()
            {
                Id = ADMIN_ID,
                Email = "Admin@byMe.com",
                EmailConfirmed = true,
                UserName = "Admin@byMe.com",
                NormalizedEmail = "ADMIN@byMe.COM",
                NormalizedUserName = "ADMIN@byMe.COM"
            };
            //set user password
            PasswordHasher<ApplicationUser> ph = new PasswordHasher<ApplicationUser>();
            appUser.PasswordHash = ph.HashPassword(appUser, "P@ssword1");
            modelBuilder.Entity<ApplicationUser>().HasData(appUser);
            base.OnModelCreating(modelBuilder);
        }
    }
}
