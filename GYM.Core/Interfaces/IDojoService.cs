using GYM.Core.CustomEntities;
using GYM.Core.Entities;
using GYM.Core.QueryFilters;

namespace GYM.Core.Interfaces
{
    public interface IDojoService
    {
        PagedList<Dojo> GetDojos(DojoQueryFIlter filters);
        Task<Dojo> GetDojo(int id);
        Task InsertDojo(Dojo dojos);
        Task UpdateDojo(Dojo dojo);
        Task<bool> DeleteDojo(int id);
    }
}