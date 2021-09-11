using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    /// <summary>
    /// Domain object class BankInstallmentDO
    /// </summary>
    public class BankInstallmentDO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Bankid { get; set; }
        public int Installmentcount { get; set; }
        public decimal Rate { get; set; }
        public int Order { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual BankDO Bank { get; set; }
    }
}
