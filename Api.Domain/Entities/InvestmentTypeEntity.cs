namespace Domain.Entities
{
    public class InvestmentTypeEntity : BaseEntity
    {
        public string? Name { get;  set; }

        public ICollection<InvestmentEntity>? Investments { get;  set; }
    }
}