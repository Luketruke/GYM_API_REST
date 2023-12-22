using GYM.Core.CustomEntities;
using GYM.Core.Entities;
using GYM.Core.Interfaces;
using GYM.Core.Interfaces.Repositories;
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

            var pagedFighters = PagedList<Fighter>.Create(fighters.ToList(), filters.PageNumber, filters.PageSize);

            return pagedFighters;
        }
        public async Task<bool> InsertFighter(Fighter fighter)
        {
            try
            {
                await _unitOfWork.FighterRepository.Add(fighter);
                return await _unitOfWork.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
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
            return await _unitOfWork.SaveChangesAsync() > 0;
        }
    }
}
