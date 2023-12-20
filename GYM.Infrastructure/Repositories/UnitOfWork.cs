using GYM.Core.Entities;
using GYM.Core.Interfaces;
using GYM.Infrastructure.Data;

namespace GYM.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GymContext _context;
        private readonly IDojoRepository _dojoRepository;
        private readonly ILoginRepository _loginRepository;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Event> _eventRepository;
        private readonly IFighterRepository _fighterRepository;
        private readonly IRepository<Fight> _fightRepository;
        private readonly IRepository<Province> _provinceRepository;
        private readonly IRepository<Locality> _localityRepository;
        public UnitOfWork(GymContext context)
        {
            _context = context;
        }

        public IDojoRepository DojoRepository => _dojoRepository ?? new DojoRepository(_context);
        public ILoginRepository LoginRepository => _loginRepository ?? new LoginRepository(_context);
        public IRepository<User> UserRepository => _userRepository ?? new BaseRepository<User>(_context);
        public IRepository<Event> EventRepository => _eventRepository ?? new BaseRepository<Event>(_context);
        public IFighterRepository FighterRepository => _fighterRepository ?? new FighterRepository(_context);
        public IRepository<Fight> FightRepository => _fightRepository ?? new BaseRepository<Fight>(_context);
        public IRepository<Province> ProvinceRepository => _provinceRepository ?? new BaseRepository<Province>(_context);
        public IRepository<Locality> LocalityRepository => _localityRepository ?? new BaseRepository<Locality>(_context);

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
