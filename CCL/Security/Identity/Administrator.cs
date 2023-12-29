using System;
using System.Collections.Generic;
using System.Text;
using CCL.Security.Identity;
using DAL.Entities.Enum;

namespace OSBB.Security.Identity
{
    public class Administrator
        : User
    {
        public Administrator(int userId, string login, string password, string name, string surname, string email)
            : base(userId, login, password, name, surname, email, Role.Administrator)
        {
        }
    }
}