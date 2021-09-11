﻿using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.MySqlDbContext
{
    public partial class Orderitem
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

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
        public virtual User User { get; set; }
    }
}
