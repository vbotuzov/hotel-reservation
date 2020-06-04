using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Room
    {
        public int room_number { get; set; }
        public int numb_of_place { get; set; }
        public string comfortable { get; set; }
        public int prize { get; set; }

        public Ord Ord { get; set; }
    }
}