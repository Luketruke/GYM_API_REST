using GYM.Core.Entities;
using GYM.Infrastructure.Data;

namespace GYM.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User>
    {
        public UserRepository(GymContext context) : base(context) { }
    }
}
