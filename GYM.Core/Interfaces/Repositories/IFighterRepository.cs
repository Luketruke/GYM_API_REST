using GYM.Core.Entities;
using GYM.Core.Interfaces.Repositories;

namespace GYM.Core.Interfaces
{
    public interface IFighterRepository : IRepository<Fighter>
    {
        IEnumerable<Fighter> GetFighters();
    }
}
