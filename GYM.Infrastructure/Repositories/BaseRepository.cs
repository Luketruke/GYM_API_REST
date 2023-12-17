using GYM.Core.Entities;
using GYM.Core.Interfaces;
using GYM.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GYM.Infrastructure.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly GymContext _context;
        protected readonly DbSet<T> _entities;
        public BaseRepository(GymContext context)
        {
            _context = context;
            _entities = _context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _entities.AsEnumerable();
        }

        public async Task<T> GetById(int id)
        {
            return await _entities.FindAsync(id);
        }
        public async Task Add(T entity)
        {
            await _entities.AddAsync(entity);
        }
        public void Update(T entity)
        {
            _entities.Update(entity);
        }
        public async Task Delete(int id)
        {
            T entityToDelete = await GetById(id);
            _entities.Remove(entityToDelete);
        }
    }
}
