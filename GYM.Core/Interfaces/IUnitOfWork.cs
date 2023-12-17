using GYM.Core.Entities;

namespace GYM.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IDojoRepository DojoRepository { get; }
        ILoginRepository LoginRepository { get; }
        IRepository<User> UserRepository { get; }
        IRepository<Event> EventRepository { get; }
        IRepository<Fighter> FighterRepository { get; }
        IRepository<Fight> FightRepository { get; }
        IRepository<Locality> LocalityRepository { get; }
        IRepository<Province> ProvinceRepository { get; }
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
