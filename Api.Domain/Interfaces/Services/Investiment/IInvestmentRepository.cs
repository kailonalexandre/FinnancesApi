using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Api.Domain.Interfaces.Services.Investiment
{
    public interface IInvestmentRepository
    { 
        Task<InvestmentEntity> GetByIdAsync(Guid id);
        Task<IEnumerable<InvestmentEntity>> GetAllAsync();
        Task<InvestmentEntity> CreateAsync(InvestmentEntity investment);
        Task<InvestmentEntity> UpdateAsync(InvestmentEntity investment);
        Task<bool> DeleteAsync(Guid id);

        // Extra: simulações ou projeções
        Task<decimal> GetProjectedReturnAsync(int investmentId, int months);
    }
}