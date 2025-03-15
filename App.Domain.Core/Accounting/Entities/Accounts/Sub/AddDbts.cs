using App.Domain.Core.Accounting.Entities.Enum;
using App.Domain.Core.Accounting.Entities.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Accounting.Entities.Accounts.Sub
{
    public class AddDbts
    {
        public int Id { get; set; }
        public string Title { get; set; }

        [Range(0.01, 100000000000.00, ErrorMessage = "The amount must be between 0.01 and 100,000,000,000.")]
        public decimal Amount { get; set; }
        public string? Description { get; set; }
        public bool IsDeleted { get; set; }

        public PersonCondition personConditions { get; set; }

        public int DebtsId { get; set; }
        public Debts Debt { get; set; }
        public int UserId { get; set; }
        public User Users { get; set; }
    }
}
