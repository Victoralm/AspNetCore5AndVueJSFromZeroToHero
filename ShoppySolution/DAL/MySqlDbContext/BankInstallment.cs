using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.MySqlDbContext
{
    public partial class BankInstallment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Bankid { get; set; }
        public int Installmentcount { get; set; }
        public decimal Rate { get; set; }
        public int Order { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual Bank Bank { get; set; }
    }
}
