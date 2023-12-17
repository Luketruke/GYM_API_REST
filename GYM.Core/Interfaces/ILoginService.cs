using GYM.Core.Entities;

namespace GYM.Core.Interfaces
{
    public interface ILoginService
    {
        Task<Security> GetLoginByCredentials(UserLogin userLogin);
        Task RegisterUser(Security security);
    }
}