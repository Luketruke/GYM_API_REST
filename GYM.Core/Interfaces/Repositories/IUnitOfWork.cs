using GYM.Core.Entities;

namespace GYM.Core.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IDojoRepository DojoRepository { get; }
        ILoginRepository LoginRepository { get; }
        IRepository<User> UserRepository { get; }
        IRepository<Event> EventRepository { get; }
        IFighterRepository FighterRepository { get; }
        IRepository<Fight> FightRepository { get; }
        IRepository<Locality> LocalityRepository { get; }
        IRepository<Province> ProvinceRepository { get; }
        void SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
