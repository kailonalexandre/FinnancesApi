using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class InvestmentEntity : BaseEntity
    {
        public string? Name { get;  set; }
        public decimal InvestedAmount { get; set; }
        public decimal CurrentValue { get; set; }
        public Guid InvestmentTypeId { get;  set; }
        public InvestmentTypeEntity? InvestmentType { get; set; }
    }
}
