using DAL.Entities.Enum;

namespace DAL.Entities
{
    public class User
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public Role UserRole { get; set; }
    }
}