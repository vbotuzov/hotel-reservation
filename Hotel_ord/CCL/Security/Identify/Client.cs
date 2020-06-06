using System;
using System.Collections.Generic;
using System.Text;

namespace CCL.Security.Identify
{
    public class Client
        : User
    {
        public Client(int userId, string name, int ordId)
            : base(userId, name, ordId, nameof(Client))
        {
        }
    }
}
