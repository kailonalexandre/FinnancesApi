using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class InvestmentEntity : BaseEntity
    {
        public string Name { get; private set; }
        public decimal InvestedAmount { get; private set; }
        public decimal CurrentValue { get; private set; }
        public Guid InvestmentTypeId { get; private set; }
        public InvestmentTypeEntity InvestmentType { get; private set; }
    }
}
