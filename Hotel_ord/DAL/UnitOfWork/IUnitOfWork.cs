using DAL.Entities;
using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IOrdRepository Ords { get; }
        IPersonRepository Persons { get; }
        IRoomRepository Rooms { get; }
        IAdminRepository Admins { get; }
        void Save();
    }
}