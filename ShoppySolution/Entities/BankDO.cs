using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    /// <summary>
    /// Domain object class BankDO
    /// </summary>
    public class BankDO
    {
        
        public BankDO()
        {
            BankInstallments = new List<BankInstallmentDO>();
        }

        public int Id { get; set; }
        public string Logo { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? Installment { get; set; }
        public int? Order { get; set; }
        public string Iban { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual List<BankInstallmentDO> BankInstallments { get; set; }
    }
}
