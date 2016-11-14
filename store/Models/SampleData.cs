using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

namespace store.Models
{
    public class YourDbContextSeedData
    {
        private ApplicationDbContext _context;

        public YourDbContextSeedData(ApplicationDbContext context)
        {
            _context = context;
        }



        public async void SeedUser()
        {
            var passwordHash = new PasswordHasher();
            string password = passwordHash.HashPassword("Password@123");

            var user = new ApplicationUser
            {
                UserName = "Email@email.com",
                Email = "Email@email.com",
                EmailConfirmed = true,
                PhoneNumber = "070123456",
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString(),
                PasswordHash = password,
            };

            await _context.SaveChangesAsync();
        }
    }
}