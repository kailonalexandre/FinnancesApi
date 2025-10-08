namespace Domain.Entities
{
    public class CategoryEntity : BaseEntity
    {
        public string? Name { get;  set; }
        public string? Type { get;  set; } // "Income" or "Expense"
        public string? Color { get;  set; }

        public ICollection<FinancialAccountEntity>? FinancialAccounts { get;  set; }
    }
}