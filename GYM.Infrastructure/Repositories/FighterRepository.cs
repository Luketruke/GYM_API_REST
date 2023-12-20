using GYM.Core.DTOs;
using GYM.Core.Entities;
using GYM.Core.Enumerators;
using GYM.Core.Interfaces;
using GYM.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GYM.Infrastructure.Repositories
{
    public class FighterRepository : BaseRepository<Fighter>, IFighterRepository
    {
        public FighterRepository(GymContext context) : base(context) { }

        
    }
}
