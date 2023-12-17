using GYM.Core.Entities;
using GYM.Core.Interfaces;

namespace GYM.Core.Services
{
    public class AddressService : IAddressService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AddressService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Province> GetProvince(int id)
        {
            return await _unitOfWork.ProvinceRepository.GetById(id);
        }

        public async Task<Locality> GetLocality(int id)
        {
            return await _unitOfWork.LocalityRepository.GetById(id);
        }

        public List<Province> GetProvinces()
        {
            var addresses = _unitOfWork.ProvinceRepository.GetAll();

            var provinces = addresses.Select(a => new Province
            {
                Description = a.Description,
                Id = a.Id,
            }).Distinct().ToList();

            return provinces;
        }
        public List<Locality> GetLocalities()
        {
            var addresses = _unitOfWork.LocalityRepository.GetAll();

            var localities = addresses.Select(a => new Locality
            {
                Description = a.Description,
                Id = a.Id,
                ProvinceId = a.ProvinceId,
            }).Distinct().ToList();

            return localities;
        }
    }
}
