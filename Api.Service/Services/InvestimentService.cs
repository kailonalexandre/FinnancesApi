using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services.Investiment;
using Domain.Entities;

namespace Api.Service.Services
{
    public class InvestmentService : IInvestmentRepository
    {
        private IRepository<InvestmentEntity> _repository;

        public InvestmentService(IRepository<InvestmentEntity> repository)
        {
            _repository = repository;
        }

        public async Task<InvestmentEntity> CreateAsync(InvestmentEntity investment)
        {
           return await _repository.InsertAsync(investment);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
           return await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<InvestmentEntity>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<InvestmentEntity> GetByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<InvestmentEntity> UpdateAsync(InvestmentEntity investment)
        {
           return await _repository.UpdateAsync(investment);
        }
    }
}