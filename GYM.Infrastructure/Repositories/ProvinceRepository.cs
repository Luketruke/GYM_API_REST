using GYM.Core.Entities;
using GYM.Infrastructure.Data;

namespace GYM.Infrastructure.Repositories
{
    public class ProvinceRepository : BaseRepository<Province>
    {
        public ProvinceRepository(GymContext context) : base(context) { }
    }
}
