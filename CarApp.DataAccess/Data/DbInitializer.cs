using CarApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Migration Failed");
            }

            _userManager.CreateAsync(new ApplicationUser
            {
                UserName = "origin@carapp.com",
                Email = "origin@carapp.com",
                FirstName = "Origin",
                LastName = "Test",
                EmailConfirmed = true
            }, "Letmein123!").GetAwaiter().GetResult();

            Event event1 = new Event() {
                Title = "Mustang Showing",
                DateStart = new DateTime(2020, 11, 05),
                DateEnd = new DateTime(2020, 11, 06),
                DateCreated = new DateTime(2020, 10, 27),
                Description = 
                "Come see the vintage cars. Drinks, food and gifts." +
                "Cras justo odio, dapibus ac facilisis in, egestas eget quam. " +
                "Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit."
            };

            _db.Events.Add(event1);
           
         
            await _db.SaveChangesAsync();

        }
    }
}
