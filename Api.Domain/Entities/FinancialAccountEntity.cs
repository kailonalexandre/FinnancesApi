using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class FinancialAccountEntity : BaseEntity
    {
        public string? Name { get;  set; } //Nome da despesa ou receita
        public decimal Amount { get;  set; } //Valor da despesa ou receita
        public DateTime Date { get;  set; } //Data da despesa ou receita
        public string? Type { get;  set; } //Tipo da despesa ou receita (Despesa ou Receita)
        public Guid CategoryId { get;  set; } //Categoria da despesa ou receita
        public CategoryEntity? Category { get;  set; } //Categoria da despesa ou receita
    }
}
