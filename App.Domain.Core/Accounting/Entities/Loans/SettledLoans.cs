using App.Domain.Core.Accounting.Entities.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Accounting.Entities.Loans
{
    public class SettledLoans
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public int Name { get; set; }

        [Range(0.01, 100000000000.00, ErrorMessage = "The amount must be between 0.01 and 100,000,000,000.")]
        public decimal Amount { get; set; }
        public DateTime ReceiveTime { get; set; }
        public bool IsSpent { get; set; }
        public int MyProperty { get; set; }
        public DateTime FirstInstallmentTime { get; set; }
        public DateTime TimeFrame { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }


        public int UserId { get; set; }
        public User Users { get; set; }

    }
}
