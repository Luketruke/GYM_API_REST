using GYM.Core.CustomEntities;
using GYM.Core.Entities;
using GYM.Core.Interfaces.Repositories;
using GYM.Core.Interfaces.Services;
using GYM.Core.QueryFilters;
using Microsoft.Extensions.Options;

namespace GYM.Core.Services
{
    public class EventService : IEventService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly PaginationOptions _paginationOptions;

        public EventService(IUnitOfWork unitOfWork, IOptions<PaginationOptions> options)
        {
            _unitOfWork = unitOfWork;
            _paginationOptions = options.Value;
        }

        public async Task<Event> GetEvent(int id)
        {
            return await _unitOfWork.EventRepository.GetById(id);
        }

        public PagedList<Event> GetEvents(EventQueryFilter filters)
        {
            filters.PageNumber = filters.PageNumber <= 0 ? _paginationOptions.DefaultPageNumber : filters.PageNumber;
            filters.PageSize = filters.PageSize <= 0 ? _paginationOptions.DefaultPageSize : filters.PageSize;

            var events = _unitOfWork.EventRepository.GetAll();
            var pagedEvents = PagedList<Event>.Create(events.ToList(), filters.PageNumber, filters.PageSize);

            return pagedEvents;
        }
        public async Task<bool> InsertEvent(Event eventt)
        {
            try
            {
                await _unitOfWork.EventRepository.Add(eventt);
                return await _unitOfWork.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
        public async Task UpdateEvent(Event eventt)
        {
            _unitOfWork.EventRepository.Update(eventt);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task<bool> DeleteEvent(int id)
        {
            await _unitOfWork.EventRepository.LogicalDelete(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
