using GYM.Core.Entities;

namespace GYM.Core.Services
{
    public interface IAddressService
    {
        List<Locality> GetLocalities();
        Task<Locality> GetLocality(int id);
        Task<Province> GetProvince(int id);
        List<Province> GetProvinces();
    }
}