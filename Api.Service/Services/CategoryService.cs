using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.Category;
using Domain.Entities;

namespace Api.Service.Services
{
    public class CategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<CategoryEntity>> GetAllAsync()
        {
            return await _categoryRepository.GetAllAsync();
        }

        public async Task<CategoryEntity> GetByIdAsync(Guid id)
        {
            return await _categoryRepository.GetByIdAsync(id);
        }

        public async Task<CategoryEntity> CreateAsync(CategoryEntity category)
        {
            return await _categoryRepository.CreateAsync(category);
        }

        public async Task<CategoryEntity> UpdateAsync(CategoryEntity category)
        {
            return await _categoryRepository.UpdateAsync(category);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _categoryRepository.DeleteAsync(id);
        }
    }
}