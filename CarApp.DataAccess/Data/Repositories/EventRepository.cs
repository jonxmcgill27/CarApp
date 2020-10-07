using CarApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarApp.DataAccess.Data.Repositories
{
    public class EventRepository : Repository<Event>, IEventRepository
    {
        private readonly ApplicationDbContext _db;

        public EventRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
