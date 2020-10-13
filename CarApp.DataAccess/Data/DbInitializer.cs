using CarApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Drawing;
using System.IO;
using System.Linq;

namespace CarApp.DataAccess.Data
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IHostEnvironment _env;

        public DbInitializer(ApplicationDbContext db, UserManager<IdentityUser> userManager, IHostEnvironment env)
        {
            _db = db;
            _userManager = userManager;
            _env = env;
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

            IdentityUser user = await _db.Users.FirstOrDefaultAsync(u => u.Email == "origin@carapp.com");
            if (user != null) return;

            _userManager.CreateAsync(new ApplicationUser
            {
                UserName = "origin@carapp.com",
                Email = "origin@carapp.com",
                FirstName = "Origin",
                LastName = "Test",
                EmailConfirmed = true
            }, "Letmein123!").GetAwaiter().GetResult();


            var file = _env.ContentRootFileProvider.GetFileInfo("wwwroot\\asset\\yellow-car.jpg").CreateReadStream();
            byte[] fileBytes;
            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                fileBytes = ms.ToArray();
                file.Dispose();
            }

            EventGathering event1 = new EventGathering() {
                Title = "Mustang Showing",
                DateStart = new DateTime(2020, 11, 05),
                DateEnd = new DateTime(2020, 11, 06),
                DateCreated = new DateTime(2020, 10, 27),
                Description = 
                "Come see the vintage cars. Drinks, food and gifts." +
                "Cras justo odio, dapibus ac facilisis in, egestas eget quam. " +
                "Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.",
                Image = fileBytes
            };




            _db.Events.Add(event1);
           
         
            await _db.SaveChangesAsync();

        }
    }
}
