using Microsoft.EntityFrameworkCore;
using GYM.Core.Entities;
using GYM.Core.Interfaces;
using GYM.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM.Infrastructure.Repositories
{
    public class FightRepository : IFightRepository
    {
        private readonly GymContext _context;

        public FightRepository(GymContext context)
        {
            _context = context;
        }
    }
}
