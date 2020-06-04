using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using DAL.EF;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DAL.Repositories.Impl
{
    public class RoomRepository
        : BaseRepository<Room>, IRoomRepository
    {

        internal RoomRepository(Hotel_ordContext context)
            : base(context)
        {
        }
    }
}