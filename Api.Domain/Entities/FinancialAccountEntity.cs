using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class FinancialAccountEntity : BaseEntity
    {
        public string? Name { get; private set; } //Nome da despesa ou receita
        public decimal Amount { get; private set; } //Valor da despesa ou receita
        public DateTime Date { get; private set; } //Data da despesa ou receita
        public string? Type { get; private set; } //Tipo da despesa ou receita (Despesa ou Receita)
        public Guid CategoryId { get; private set; } //Categoria da despesa ou receita
        public CategoryEntity? Category { get; private set; } //Categoria da despesa ou receita
    }
}
