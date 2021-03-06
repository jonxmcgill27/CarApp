﻿using System;
using System.Collections.Generic;
using System.Text;
using CarApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarApp.DataAccess
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<EventGathering> Events { get; set; }
        public DbSet<Car> Cars { get; set; }
    }
}
