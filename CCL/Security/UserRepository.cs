using DAL.EF;
using DAL.Entities;
using DAL.Repositories.Impl;

namespace CCL.Security
{
    public class UserRepository
        : BaseRepository<User>
    {
        public UserRepository(TenderContext context) : base(context)
        {
        }
    }
}