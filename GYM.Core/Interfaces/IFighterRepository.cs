using GYM.Core.DTOs;
using GYM.Core.Entities;

namespace GYM.Core.Interfaces
{
    public interface IFighterRepository : IRepository<Fighter>
    {
        IEnumerable<Fighter> GetFighters();
    }
}
