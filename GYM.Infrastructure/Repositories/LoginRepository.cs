using GYM.Core.Entities;
using GYM.Core.Interfaces;
using GYM.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GYM.Infrastructure.Repositories
{
    public class LoginRepository : BaseRepository<Security>, ILoginRepository
    {
        public LoginRepository(GymContext context) : base(context) { }

        public async Task<Security> GetLoginByCredentials(UserLogin login)
        {
            return await _entities.FirstOrDefaultAsync(x => x.User == login.User);
        }
    }
}
