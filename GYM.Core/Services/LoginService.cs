using GYM.Core.Entities;
using GYM.Core.Interfaces;

namespace GYM.Infrastructure.Services
{
    public class LoginService : ILoginService
    {
        private readonly IUnitOfWork _unitOfWork;
        public LoginService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Security> GetLoginByCredentials(UserLogin userLogin)
        {
            return await _unitOfWork.LoginRepository.GetLoginByCredentials(userLogin);
        }

        public async Task RegisterUser(Security security)
        {
            await _unitOfWork.LoginRepository.Add(security);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
