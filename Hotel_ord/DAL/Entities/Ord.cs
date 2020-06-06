using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Ord
    {
        public int id_ord { get; set; }
        public int order_id { get; set; }
        public string room_id { get; set; }
        public int admin_id { get; set; }

        public List<Person> Persons { get; set; }
        public List<Room> Rooms { get; set; }
        public List<Admin> Admins { get; set; }
    }
}