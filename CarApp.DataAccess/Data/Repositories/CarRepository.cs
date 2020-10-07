using CarApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarApp.DataAccess.Data.Repositories
{
    public class CarRepository : Repository<Car>, ICarRepository
    {
        private readonly ApplicationDbContext _db;

        public CarRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
