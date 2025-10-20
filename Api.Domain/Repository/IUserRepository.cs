using Api.Domain.Interfaces;
using Domain.Entities;

namespace Api.Domain.Repository
{
    public interface IUserRepository : IRepository<UserEntity>
    {
        Task<UserEntity> FindByLogin(string email);
        
    }

}