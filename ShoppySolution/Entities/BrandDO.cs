using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    /// <summary>
    /// Domain object class BrandDO
    /// </summary>
    public class BrandDO
    {
        public BrandDO()
        {
            Products = new List<ProductDO>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public int? Displayorder { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual List<ProductDO> Products { get; set; }
    }
}
