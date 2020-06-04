using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Admin
    {
        public int id { get; set; }
        public string admin_name { get; set; }
        public int admin_password { get; set; }

        public Ord Ord { get; set; }
    }
}