using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Api.Domain.Interfaces.Services.Category
{
    public interface ICategoryRepository
    {
        Task<CategoryEntity> GetByIdAsync(Guid id);
        Task<IEnumerable<CategoryEntity>> GetAllAsync();
        Task<CategoryEntity> CreateAsync(CategoryEntity category);
        Task<CategoryEntity> UpdateAsync(CategoryEntity category);
        Task<bool> DeleteAsync(Guid id);
    }
}