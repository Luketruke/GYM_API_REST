using GYM.Core.Entities;
using GYM.Infrastructure.Data;

namespace GYM.Infrastructure.Repositories
{
    public class LocalityRepository : BaseRepository<Locality>
    {
        public LocalityRepository(GymContext context) : base(context) { }
    }
}
