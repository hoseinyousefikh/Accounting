﻿using App.Domain.Core.Accounting.Entities.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Accounting.Entities.Accounts.Sub
{
    public class Debtors
    {
        public int Id { get; set; }

        [Range(0.01, 100000000000.00, ErrorMessage = "The amount must be between 0.01 and 100,000,000,000.")]

        public decimal Amount { get; set; }
        public bool IsDeleted { get; set; }

        public string? Descriptions { get; set; }

        public int UserId { get; set; }
        public User Users { get; set; }
    }
}
