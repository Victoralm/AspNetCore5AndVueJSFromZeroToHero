using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    /// <summary>
    /// Domain object class OrderitemDO
    /// </summary>
    public class OrderitemDO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public string OrderItemGuid { get; set; }
        public int Quantity { get; set; }
        public int PaymentId { get; set; }
        public decimal? Price { get; set; }
        public decimal? WithoutDiscount { get; set; }
        public decimal? TotalPrice { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual OrderDO Order { get; set; }
        public virtual ProductDO Product { get; set; }
        public virtual UserDO User { get; set; }
    }
}
