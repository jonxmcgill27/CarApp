using System;
using System.Collections.Generic;
using System.Text;

namespace CarApp.DataAccess.Data.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IEventRepository Event { get; }
        ICarRepository Car { get; }
        void Save();
    }
}
