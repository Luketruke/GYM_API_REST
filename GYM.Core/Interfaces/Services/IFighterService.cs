using GYM.Core.CustomEntities;
using GYM.Core.Entities;
using GYM.Core.QueryFilters;

namespace GYM.Core.Interfaces
{
    public interface IFighterService
    {
        Task<bool> DeleteFighter(int id);
        Task<Fighter> GetFighter(int id);
        PagedList<Fighter> GetFighters(FighterQueryFilter filters);
        Task<bool> InsertFighter(Fighter fighter);
        Task UpdateFighter(Fighter fighter);
    }
}