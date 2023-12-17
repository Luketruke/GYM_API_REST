using GYM.Core.Interfaces;
using GYM.Infrastructure.Data;

namespace GYM.Infrastructure.Repositories
{
    public class FighterRepository : IFighterRepository
    {

        private readonly GymContext _context;

        public FighterRepository(GymContext context)
        {
            _context = context;
        }
    }
}
