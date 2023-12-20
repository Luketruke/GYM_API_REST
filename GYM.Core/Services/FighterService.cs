using GYM.Core.CustomEntities;
using GYM.Core.Entities;
using GYM.Core.Interfaces;
using GYM.Core.QueryFilters;
using Microsoft.Extensions.Options;

namespace GYM.Core.Services
{
    public class FighterService : IFighterService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly PaginationOptions _paginationOptions;

        public FighterService(IUnitOfWork unitOfWork, IOptions<PaginationOptions> options)
        {
            _unitOfWork = unitOfWork;
            _paginationOptions = options.Value;
        }

        public async Task<Fighter> GetFighter(int id)
        {
            return await _unitOfWork.FighterRepository.GetById(id);
        }

        public PagedList<Fighter> GetFighters(FighterQueryFilter filters)
        {
            filters.PageNumber = filters.PageNumber <= 0 ? _paginationOptions.DefaultPageNumber : filters.PageNumber;
            filters.PageSize = filters.PageSize <= 0 ? _paginationOptions.DefaultPageSize : filters.PageSize;

            var fighters = _unitOfWork.FighterRepository.GetFighters();

            //if (!string.IsNullOrEmpty(filters.name))
            //{
            //    fighters = fighters.Where(x => x.Name == filters.name);
            //}

            //if (!string.IsNullOrEmpty(filters.instructorName))
            //{
            //    fighters = fighters.Where(x => x.InstructorName == filters.instructorName);
            //}

            var pagedFighters = PagedList<Fighter>.Create(fighters.ToList(), filters.PageNumber, filters.PageSize);

            return pagedFighters;
        }
        public async Task InsertFighter(Fighter fighter)
        {
            try
            {
                await _unitOfWork.FighterRepository.Add(fighter);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public async Task UpdateFighter(Fighter fighter)
        {
            _unitOfWork.FighterRepository.Update(fighter);
            await _unitOfWork.SaveChangesAsync();
        }

        //Dynamic update
        //public async void UpdateFighter(Fighter fighter)
        //{
        //    var existingFighter = await _unitOfWork.FighterRepository.GetById(fighter.Id);
        //    existingFighter.Name = fighter.Name;
        //    existingFighter.InstructorName = fighter.InstructorName;

        //    _unitOfWork.FighterRepository.Update(existingFighter);
        //    await _unitOfWork.SaveChangesAsync();
        //}
        public async Task<bool> DeleteFighter(int id)
        {
            await _unitOfWork.FighterRepository.LogicalDelete(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
