using App.Domain.Core.Accounting.Entities.Accounts;
using App.Domain.Core.Accounting.Entities.Enum;
using App.Domain.Core.Accounting.Entities.payment;
using App.Domain.Core.Accounting.Entities.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Accounting.Entities.Reports
{
    public class ListExpenses
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        [Range(0.01, 100000000000.00, ErrorMessage = "The amount must be between 0.01 and 100,000,000,000.")]
        public decimal Amount { get; set; }
        public DateTime DueDate { get; set; }
        public string? CheckNumber { get; set; }
        public bool IsDeleted { get; set; }

        public PaymentType PaymentType { get; set; }
        public int BankId { get; set; }
        public Bank Banks { get; set; }
        public int UserId { get; set; }
        public User Users { get; set; }
    }
}
