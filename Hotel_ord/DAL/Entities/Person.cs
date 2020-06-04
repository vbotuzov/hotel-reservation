using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Person
    {
        public int pasport_id { get; set; }
        public string person_surname { get; set; }
        public string person_name { get; set; }
        public string person_fathername { get; set; }
        public string adress { get; set; }

        public Ord Ord { get; set; }
    }
}