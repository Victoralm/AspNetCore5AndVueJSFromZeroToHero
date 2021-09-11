﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    /// <summary>
    /// Domain object class UserDO
    /// </summary>
    public class UserDO
    {
        public UserDO()
        {
            Addresses = new List<AddressDO>();
            Baskets = new List<BasketDO>();
            Orderitems = new List<OrderitemDO>();
            Orders = new List<OrderDO>();
            Payments = new List<PaymentDO>();
            Resetpasswords = new List<ResetpasswordDO>();
            Wishlists = new List<WishlistDO>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? Maillist { get; set; }
        public DateTime? Birthday { get; set; }
        public int Gender { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int? Country { get; set; }
        public int? Cityid { get; set; }
        public string Citytext { get; set; }
        public int? District { get; set; }
        public string Zipcode { get; set; }
        public string Valid { get; set; }
        public int? Customertype { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual CityDO City { get; set; }
        public virtual List<AddressDO> Addresses { get; set; }
        public virtual List<BasketDO> Baskets { get; set; }
        public virtual List<OrderitemDO> Orderitems { get; set; }
        public virtual List<OrderDO> Orders { get; set; }
        public virtual List<PaymentDO> Payments { get; set; }
        public virtual List<ResetpasswordDO> Resetpasswords { get; set; }
        public virtual List<WishlistDO> Wishlists { get; set; }
    }
}
