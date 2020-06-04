using DAL.Entities;
using DAL.Repositories.Impl;
using DAL.Repositories.Interfaces;
using DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;

namespace DAL.EF
{
    public class EFUnitOfWork
        : IUnitOfWork
    {
        private Hotel_ordContext db;
        private OrdRepository ordRepository;
        private PersonRepository personRepository;
        private RoomRepository roomRepository;
        private AdminRepository adminRepository;

        public EFUnitOfWork(Hotel_ordContext context)
        {
            db = context;
        }

        public IOrdRepository Ords
        {
            get
            {
                if (ordRepository == null)
                    ordRepository = new OrdRepository(db);
                return ordRepository;
            }
        }

        public IPersonRepository Persons
        {
            get
            {
                if (personRepository == null)
                    personRepository = new PersonRepository(db);
                return personRepository;
            }
        }

        public IRoomRepository Rooms
        {
            get
            {
                if (roomRepository == null)
                    roomRepository = new RoomRepository(db);
                return roomRepository;
            }
        }

        public IAdminRepository Admins
        {
            get
            {
                if (adminRepository == null)
                    adminRepository = new AdminRepository(db);
                return adminRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}