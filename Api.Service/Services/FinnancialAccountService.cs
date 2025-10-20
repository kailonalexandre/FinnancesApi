using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services.Account;
using Domain.Entities;


namespace Api.Service.Services
{
    public class FinnancialAccountService : IFinnancialAccountRepository
    {
        private IRepository<FinancialAccountEntity> _repository;

        public FinnancialAccountService(IRepository<FinancialAccountEntity> repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<FinancialAccountEntity> GetByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<FinancialAccountEntity>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<FinancialAccountEntity> CreateAsync(FinancialAccountEntity account, Guid CategoryId)
        {
            account.CategoryId = CategoryId;
            return await _repository.InsertAsync(account);
        }

        public async Task<FinancialAccountEntity> UpdateAsync(FinancialAccountEntity account)
        {
            if (account == null)
                throw new ArgumentNullException(nameof(account));

            return await _repository.UpdateAsync(account);
        }
    }
}