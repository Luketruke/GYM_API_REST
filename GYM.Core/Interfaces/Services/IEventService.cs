using GYM.Core.CustomEntities;
using GYM.Core.Entities;
using GYM.Core.QueryFilters;

namespace GYM.Core.Interfaces.Services
{
    public interface IEventService
    {
        Task<Event> GetEvent(int id);
        PagedList<Event> GetEvents(EventQueryFilter filters);
        Task<bool> InsertEvent(Event eventt);
    }
}