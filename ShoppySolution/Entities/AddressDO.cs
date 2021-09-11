using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class AddressDO
    {
        /// <summary>
        /// Domain object class AddressDO
        /// </summary>
        public AddressDO()
        {
            OrderDeliveryAddresses = new List<OrderDO>();
            OrderInvoiceAddresses = new List<OrderDO>();
        }

        public int Id { get; set; }
        public int Userid { get; set; }
        public string Addresname { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address1 { get; set; }
        public string Zipcode { get; set; }
        public int? Country { get; set; }
        public int Cityid { get; set; }
        public string Phone { get; set; }
        public int? IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual CityDO City { get; set; }
        public virtual UserDO User { get; set; }
        public virtual List<OrderDO> OrderDeliveryAddresses { get; set; }
        public virtual List<OrderDO> OrderInvoiceAddresses { get; set; }
    }
}
