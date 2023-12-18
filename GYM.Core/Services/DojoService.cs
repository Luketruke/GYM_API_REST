using GYM.Core.CustomEntities;
using GYM.Core.Entities;
using GYM.Core.Interfaces;
using GYM.Core.QueryFilters;
using Microsoft.Extensions.Options;

namespace GYM.Core.Services
{
    public class DojoService : IDojoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly PaginationOptions _paginationOptions;

        public DojoService(IUnitOfWork unitOfWork, IOptions<PaginationOptions> options)
        {
            _unitOfWork = unitOfWork;
            _paginationOptions = options.Value;
        }

        public async Task<Dojo> GetDojo(int id)
        {
            return await _unitOfWork.DojoRepository.GetById(id);
        }

        public PagedList<Dojo> GetDojos(DojoQueryFIlter filters)
        {
            filters.PageNumber = filters.PageNumber <= 0 ? _paginationOptions.DefaultPageNumber : filters.PageNumber;
            filters.PageSize = filters.PageSize <= 0 ? _paginationOptions.DefaultPageSize : filters.PageSize;

            var dojos = _unitOfWork.DojoRepository.GetAllDojos();

            if (!string.IsNullOrEmpty(filters.name))
            {
                dojos = dojos.Where(x => x.Name == filters.name);
            }

            if (!string.IsNullOrEmpty(filters.instructorName))
            {
                dojos = dojos.Where(x => x.InstructorName == filters.instructorName);
            }

            var pagedDojos = PagedList<Dojo>.Create(dojos.ToList(), filters.PageNumber, filters.PageSize);

            return pagedDojos;
        }
        public async Task InsertDojo(Dojo dojo)
        {
            try
            {
                await _unitOfWork.DojoRepository.Add(dojo);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());   
            }
        }
        public async Task UpdateDojo(Dojo dojo)
        {
            _unitOfWork.DojoRepository.Update(dojo);
            await _unitOfWork.SaveChangesAsync();
        }

        //Dynamic update
        //public async void UpdateDojo(Dojo dojo)
        //{
        //    var existingDojo = await _unitOfWork.DojoRepository.GetById(dojo.Id);
        //    existingDojo.Name = dojo.Name;
        //    existingDojo.InstructorName = dojo.InstructorName;

        //    _unitOfWork.DojoRepository.Update(existingDojo);
        //    await _unitOfWork.SaveChangesAsync();
        //}
        public async Task<bool> DeleteDojo(int id)
        {
            await _unitOfWork.DojoRepository.LogicalDelete(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
