using System;
using System.Collections.Generic;
using System.Text;

namespace CCL.Security.Identify
{
    public class Admin1
        : User
    {
        public Admin1(int userId, string name, int ordId)
            : base(userId, name, ordId, nameof(Admin1))
        {
        }
    }
}
