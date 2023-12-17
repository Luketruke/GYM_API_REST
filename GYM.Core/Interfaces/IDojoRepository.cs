using GYM.Core.Entities;

namespace GYM.Core.Interfaces
{
    public interface IDojoRepository : IRepository<Dojo>
    {
        Task<IEnumerable<Dojo>> GetDojoByName(string name);
    }
}
