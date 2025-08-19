using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services.User;
using Domain.Entities;

namespace Api.Service.Services
{
    public class UserService : IUserService
    {
        private IRepository<UserEntity> _repository;
        public UserService(IRepository<UserEntity> repository)
        {
            _repository = repository;
        }

        public async Task<UserEntity> Get(Guid id)
        {
           return await _repository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<UserEntity>> GetAll()
        {
           return await _repository.GetAllAsync();
        }

        public async Task<UserEntity> Post(UserEntity user)
        {
            return await _repository.InsertAsync(user);
        }

        public async Task<UserEntity> Put(UserEntity user)
        {
           return await _repository.UpdateAsync(user);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}