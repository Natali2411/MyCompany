using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyCompany.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCompany.Domain
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<TextField> TextFields { get; set; }

        public DbSet<ServiceItem> ServiceItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "7672692f-df91-4155-b588-102743d1c007",
                Name = "admin",
                NormalizedName = "ADMIN"
            });

            modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = "c32c1fa4-7080-4573-9b12-c3da84429b11",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "nat.tiutiunnyk@gmail.com",
                NormalizedEmail = "NAT.TIUTIUNNYK@GMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "superpassword"),
                SecurityStamp = string.Empty
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "7672692f-df91-4155-b588-102743d1c007",
                UserId = "c32c1fa4-7080-4573-9b12-c3da84429b11",
            });

            modelBuilder.Entity<TextField>().HasData(new TextField
            {
                Id = new Guid("0c012463-5719-4e0e-b329-6ff69189f8a0"),
                CodeWord = "PageIndex",
                Title = "Main"
            });

            modelBuilder.Entity<TextField>().HasData(new TextField
            {
                Id = new Guid("3ff14dac-f09b-4eb0-800e-8e66b917c582"),
                CodeWord = "PageServices",
                Title = "Our services"
            });

            modelBuilder.Entity<TextField>().HasData(new TextField
            {
                Id = new Guid("0bb53959-3f65-46d1-b33c-3a96893fb4a5"),
                CodeWord = "PageContacts",
                Title = "Contacts"
            });
        }

        internal object Entry<T>()
        {
            throw new NotImplementedException();
        }
    }
}
