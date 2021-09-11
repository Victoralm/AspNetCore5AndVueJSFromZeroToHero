using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    /// <summary>
    /// Domain object class BasketDO
    /// </summary>
    public class BasketDO
    {
        public int Id { get; set; }
        public int Userid { get; set; }
        public int Productid { get; set; }
        public int Piece { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ProductDO Product { get; set; }
        public virtual UserDO User { get; set; }
    }
}
