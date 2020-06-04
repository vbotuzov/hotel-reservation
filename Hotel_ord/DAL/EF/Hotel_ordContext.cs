using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.EF
{
    public class Hotel_ordContext
        : DbContext
    {
        public DbSet<Ord> Ords { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Room> Rooms { get; set; }

        public Hotel_ordContext(DbContextOptions options)
            : base(options)
        {
        }

    }
}