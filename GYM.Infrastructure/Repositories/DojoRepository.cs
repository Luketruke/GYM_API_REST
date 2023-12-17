using GYM.Core.Entities;
using GYM.Core.Interfaces;
using GYM.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GYM.Infrastructure.Repositories
{
    public class DojoRepository : BaseRepository<Dojo>, IDojoRepository
    {
        public DojoRepository(GymContext context) : base(context) { }

        public async Task<IEnumerable<Dojo>> GetDojoByName(string name)
        {
            return await _entities.Where(x => x.Name == name).ToListAsync();
        }
    }
}
