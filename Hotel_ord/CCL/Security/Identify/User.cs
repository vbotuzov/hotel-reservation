using System;
using System.Collections.Generic;
using System.Text;

namespace CCL.Security.Identify
{
    public abstract class User
    {
        public User(int userId, string name, int ordId, string userType)
        {
            UserId = userId;
            Name = name;
            OrdID = ordId;
            UserType = userType;
        }
        public int UserId { get; }
        public string Name { get; }
        public int OrdID { get; }
        protected string UserType { get; }
    }
}
