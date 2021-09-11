using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    /// <summary>
    /// Domain object class ProductImageDO
    /// </summary>
    public class ProductImageDO
    {
        public int Id { get; set; }
        public int Productid { get; set; }
        public string Address { get; set; }
        public int Orderby { get; set; }

        public virtual ProductDO Product { get; set; }
    }
}
