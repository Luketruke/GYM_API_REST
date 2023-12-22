﻿using GYM.Core.CustomEntities;
using GYM.Core.Entities;
using GYM.Core.Interfaces;
using GYM.Core.Interfaces.Repositories;
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

        public PagedList<Dojo> GetDojos(DojoQueryFilter filters)
        {
            filters.PageNumber = filters.PageNumber <= 0 ? _paginationOptions.DefaultPageNumber : filters.PageNumber;
            filters.PageSize = filters.PageSize <= 0 ? _paginationOptions.DefaultPageSize : filters.PageSize;

            var dojos = _unitOfWork.DojoRepository.GetDojos();

            //Example of possible filters
            //if (!string.IsNullOrEmpty(filters.name))
            //{
            //    dojos = dojos.Where(x => x.Name == filters.name);
            //}

            //if (!string.IsNullOrEmpty(filters.instructorName))
            //{
            //    dojos = dojos.Where(x => x.InstructorName == filters.instructorName);
            //}

            var pagedDojos = PagedList<Dojo>.Create(dojos.ToList(), filters.PageNumber, filters.PageSize);

            return pagedDojos;
        }
        public async Task<bool> InsertDojo(Dojo dojo)
        {
            try
            {
                await _unitOfWork.DojoRepository.Add(dojo);
                return await _unitOfWork.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
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
