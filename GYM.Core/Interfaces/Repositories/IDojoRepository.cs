using GYM.Core.Entities;

namespace GYM.Core.Interfaces.Repositories
{
    public interface IDojoRepository : IRepository<Dojo>
    {
        Task<IEnumerable<Dojo>> GetDojoByName(string name);
        IEnumerable<Dojo> GetDojos();
    }
}
