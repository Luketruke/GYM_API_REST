using GYM.Core.Entities;

namespace GYM.Core.Interfaces
{
    public interface ILoginRepository : IRepository<Security>
    {
        Task<Security> GetLoginByCredentials(UserLogin login);
    }
}