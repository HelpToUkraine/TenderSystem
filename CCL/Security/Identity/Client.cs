using DAL.Entities;
using DAL.Entities.Enum;

namespace CCL.Security.Identity
{
    public class Client
        : User
    {
        public Client(int userId, string login, string password, string name, string surname, string email)
            : base(userId, login, password, name, surname, email, Role.Client)
        {
        }

        public List<Tender> tenders = new List<Tender>();
    }
}