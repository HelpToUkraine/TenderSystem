using DAL.Entities.Enum;

namespace CCL.Security.Identity
{
    public class Executor : User
    {
        public Executor(int userId, string login, string password, string name, string surname, string email)
            : base(userId, login, password, name, surname, email, Role.Executor)
        {
        }
    }
}