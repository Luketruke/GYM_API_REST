using GYM.Core.Entities;
using GYM.Core.Interfaces;
using GYM.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GYM.Infrastructure.Repositories
{
    public class DojoRepository : BaseRepository<Dojo>, IDojoRepository
    {
        public DojoRepository(GymContext context) : base(context) { }

        public async Task<IEnumerable<Dojo>> GetDojoByName(string name)
        {
            var result = await _entities
                .Where(x => x.Name == name)
                .Include(x => x.Locality)
                .Include(x => x.Province)
                .ToListAsync();

            // Imprime las propiedades para verificar
            foreach (var dojo in result)
            {
                Console.WriteLine($"Dojo: {dojo.Name}, Locality: {dojo.Locality?.Description}, Province: {dojo.Province?.Description}");
            }

            return result;
        }
    }
}
