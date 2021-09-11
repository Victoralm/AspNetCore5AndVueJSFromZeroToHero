using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class BankDO
    {
        /// <summary>
        /// Domain object class BankDO
        /// </summary>
        public BankDO()
        {
            BankInstallments = new HashSet<BankInstallmentDO>();
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

        public virtual ICollection<BankInstallmentDO> BankInstallments { get; set; }
    }
}
