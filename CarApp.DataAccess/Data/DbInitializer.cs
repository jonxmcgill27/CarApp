using CarApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarApp.DataAccess.Data
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;

        public DbInitializer(ApplicationDbContext db, UserManager<IdentityUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }
        public async void Initialize()
        {
            try
            {
                if(_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("error migration");
            }

            _userManager.CreateAsync(new ApplicationUser
            {
                UserName = "origin@test.com",
                Email = "origin@test.com",
                EmailConfirmed = true,
                FirstName = "Origin",
                LastName = "Test"
            }, "Letmein123!").GetAwaiter().GetResult();

            await _db.SaveChangesAsync();
        }
    }
}
