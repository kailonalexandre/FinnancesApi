using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Api.Domain.Interfaces.Services.Account
{
    public interface IFinnancialAccountRepository
    {
        Task<FinancialAccountEntity> GetByIdAsync(Guid id);
        Task<IEnumerable<FinancialAccountEntity>> GetAllAsync();
        Task<FinancialAccountEntity> CreateAsync(FinancialAccountEntity account);
        Task<FinancialAccountEntity> UpdateAsync(FinancialAccountEntity account);
        Task<bool> DeleteAsync(Guid id);

        // Extra: consultar saldo
        Task<decimal> GetBalanceAsync(int id);
    }
}