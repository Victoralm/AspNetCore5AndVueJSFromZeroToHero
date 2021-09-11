﻿using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.MySqlDbContext
{
    public partial class Address
    {
        public Address()
        {
            OrderDeliveryAddresses = new HashSet<Order>();
            OrderInvoiceAddresses = new HashSet<Order>();
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

        public virtual City City { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Order> OrderDeliveryAddresses { get; set; }
        public virtual ICollection<Order> OrderInvoiceAddresses { get; set; }
    }
}
