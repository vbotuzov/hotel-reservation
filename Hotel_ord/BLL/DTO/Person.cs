using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class PersonDTO
    {
        public int Pasport_id { get; set; }
        public string Person_surname { get; set; }
        public string Person_name { get; set; }
        public string Person_fathername { get; set; }
        public string Adress { get; set; }
    }
}
