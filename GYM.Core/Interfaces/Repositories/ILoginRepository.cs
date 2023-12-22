using GYM.Core.Entities;
using GYM.Core.Interfaces.Repositories;

namespace GYM.Core.Interfaces
{
    public interface ILoginRepository : IRepository<Security>
    {
        Task<Security> GetLoginByCredentials(UserLogin login);
    }
}