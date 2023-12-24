using GYM.Core.Entities;
using GYM.Core.Interfaces;
using GYM.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace GYM.Infrastructure.Repositories
{
    public class FighterRepository : BaseRepository<Fighter>, IFighterRepository
    {
        private readonly ILogger<FighterRepository> _logger;

        public FighterRepository(GymContext context, ILogger<FighterRepository> logger) : base(context)
        {
            _logger = logger;
        }

        public IEnumerable<Fighter> GetFighters()
        {
            try
            {
                var result = _entities
                       .Include(x => x.Dojo)
                       .Include(x => x.Event)
                       .AsEnumerable()
                       .Where(x => x.Status == 1 && x.Dojo != null && x.Event != null);

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener luchadores: {ex.Message}");
                throw;
            }
        }
    }
}
