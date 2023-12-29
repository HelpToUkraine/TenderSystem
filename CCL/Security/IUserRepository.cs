//using Catalog.DAL.Entities;

using CCL.Security.Identity;
using DAL.Repositories.Interfaces;
using OSBB.Security.Identity;

namespace CCL.Security
{
    public interface IUserRepository
        : IRepository<User>
    {
    }
}