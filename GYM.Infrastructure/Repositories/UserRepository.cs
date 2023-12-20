using GYM.Core.Interfaces;
using GYM.Infrastructure.Data;

namespace GYM.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly GymContext _context;

        public UserRepository(GymContext context)
        {
            _context = context;
        }
    }
}
