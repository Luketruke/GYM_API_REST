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
            var result = await _entities
                .Where(x => x.Name == name && x.Status == 1)
                .ToListAsync();

            return result;
        }
        public IEnumerable<Dojo> GetAllDojos()
        {
            var result = _entities
        .Include(x => x.Locality)
        .Include(x => x.Province)
        .AsEnumerable()
        .Where(x => x.Status == 1);

            return result;
        }
    }
}
