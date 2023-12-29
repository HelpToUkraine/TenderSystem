using DAL.Entities.Enum;

namespace CCL.Security.Identity
{
    public abstract class User
    {
        public User(int userId, string login, string password, string name, string surname, string email, Role userType)
        {
            UserId = userId;
            Login = login;
            Password = password;
            Name = name;
            Surname = surname;
            Email = email;
            UserType = userType;
        }
        public int UserId { get; }
        public string Login { get; }
        public string Password { get; }
        public string Name { get; }
        public string Surname { get; }
        public string Email { get; }
        public Role UserType { get; }
    }
}