using GYM.Core.Entities;
using GYM.Infrastructure.Data;

namespace GYM.Infrastructure.Repositories
{
    public class EventRepository : BaseRepository<Event>
    {
        public EventRepository(GymContext context) : base(context) { }
    }
}
