using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    /// <summary>
    /// Domain object class ResetpasswordDO
    /// </summary>
    public class ResetpasswordDO
    {
        public int Id { get; set; }
        public int Userid { get; set; }
        public string Email { get; set; }
        public string Guid { get; set; }
        public DateTime? Lastdate { get; set; }
        public DateTime? Createdat { get; set; }

        public virtual UserDO User { get; set; }
    }
}
