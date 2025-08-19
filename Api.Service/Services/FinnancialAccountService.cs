using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.Account;
using Domain.Entities;


namespace Api.Service.Services
{
    public class FinnancialAccountService
    {
        private readonly IFinnancialAccountRepository _repository;

        public FinnancialAccountService(IFinnancialAccountRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<IEnumerable<FinancialAccountEntity>> GetAllAccountsAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<FinancialAccountEntity> GetAccountByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<FinancialAccountEntity> CreateAccountAsync(FinancialAccountEntity account)
        {
            if (account == null)
                throw new ArgumentNullException(nameof(account));

            account.Id = Guid.NewGuid();
            return await _repository.CreateAsync(account);
        }

        public async Task<FinancialAccountEntity> UpdateAccountAsync(FinancialAccountEntity account)
        {
            if (account == null)
                throw new ArgumentNullException(nameof(account));

            return await _repository.UpdateAsync(account);
        }

        public async Task<bool> DeleteAccountAsync(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}