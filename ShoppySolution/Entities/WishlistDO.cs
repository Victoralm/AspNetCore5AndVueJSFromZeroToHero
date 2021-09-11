using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    /// <summary>
    /// Domain object class WishlistDO
    /// </summary>
    public class WishlistDO
    {
        public int Id { get; set; }
        public int Userid { get; set; }
        public int Productid { get; set; }
        public DateTime? Createdat { get; set; }
        public DateTime? Updatedat { get; set; }

        public virtual ProductDO Product { get; set; }
        public virtual UserDO User { get; set; }
    }
}
