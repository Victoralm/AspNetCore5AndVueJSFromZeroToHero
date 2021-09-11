using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    /// <summary>
    /// Domain object class ShippingDO
    /// </summary>
    public class ShippingDO
    {
        public ShippingDO()
        {
            Payments = new List<PaymentDO>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public string Logo { get; set; }
        public decimal Desiprice { get; set; }
        public int Status { get; set; }
        public int Order { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual List<PaymentDO> Payments { get; set; }
    }
}
