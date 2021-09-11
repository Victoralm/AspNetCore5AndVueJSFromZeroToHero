using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    /// <summary>
    /// Domain object class UnitDO
    /// </summary>
    public class UnitDO
    {
        public UnitDO()
        {
            Products = new List<ProductDO>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Shortname { get; set; }

        public virtual List<ProductDO> Products { get; set; }
    }
}
