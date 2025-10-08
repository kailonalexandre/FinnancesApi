using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services.Category;
using Domain.Entities;

namespace Api.Service.Services
{
    public class CategoryService : ICategoryRepository
    {
        private IRepository<CategoryEntity> _repository;

        public CategoryService(IRepository<CategoryEntity> categoryRepository)
        {
            _repository = categoryRepository;
        }

        public async Task<IEnumerable<CategoryEntity>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<CategoryEntity> GetByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<CategoryEntity> CreateAsync(CategoryEntity category)
        {
            return await _repository.InsertAsync(category);
        }

        public async Task<CategoryEntity> UpdateAsync(CategoryEntity category)
        {
            return await _repository.UpdateAsync(category);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}