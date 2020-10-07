using System;
using System.Collections.Generic;
using System.Text;

namespace CarApp.DataAccess.Data.Repositories
{
    interface IUnitOfWork
    {
        IEventRepository Event { get; }
        //ICarRepository Car { get; }
        void Save();
    }
}
