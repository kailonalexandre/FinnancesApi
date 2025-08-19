using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.Investiment;
using Domain.Entities;

namespace Api.Service.Services
{
    public class InvestmentService
    {
        private readonly IInvestmentRepository _repository;

        public InvestmentService(IInvestmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<InvestmentEntity>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<InvestmentEntity> GetByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<InvestmentEntity> CreateAsync(InvestmentEntity investment)
        {
            investment.Id = Guid.NewGuid();
            investment.CreateAt = DateTime.UtcNow;
            return await _repository.CreateAsync(investment);
        }

        public async Task<InvestmentEntity?> UpdateAsync(Guid id, InvestmentEntity investment)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null)
                return null;

            existing.Name = investment.Name;
            existing.CurrentValue = investment.CurrentValue;
            existing.InvestedAmount = investment.InvestedAmount;
            existing.InvestmentType = investment.InvestmentType;
            existing.UpdateAt = DateTime.UtcNow;

            return await _repository.UpdateAsync(existing);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}