using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class OrdDTO
    {
        public int Id_ord { get; set; }
        public int Order_id { get; set; }
        public string Room_id { get; set; }
        public string Admin_id { get; set; }
        public IEnumerable<OrdDTO> Ords { get; set; }
    }
}
