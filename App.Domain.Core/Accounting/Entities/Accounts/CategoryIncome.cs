﻿using App.Domain.Core.Accounting.Entities.Accounts.Sub;
using App.Domain.Core.Accounting.Entities.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Accounting.Entities.Accounts
{
    public class CategoryIncome
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public List<SubcategoryIncome> SubcategoryIncomes { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsPublic { get; set; } 


        public int UserId { get; set; }
        public User Users { get; set; }
    }
}
