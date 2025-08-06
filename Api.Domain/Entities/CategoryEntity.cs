namespace Domain.Entities
{
    public class CategoryEntity : BaseEntity
    {
        public string Name { get; private set; }
        public string Type { get; private set; } // "Income" or "Expense"
        public string? Color { get; private set; }

        //public ICollection<FinancialAccount> FinancialAccounts { get; private set; }
    }
}