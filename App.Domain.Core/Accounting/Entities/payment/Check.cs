using App.Domain.Core.Accounting.Entities.Accounts;
using App.Domain.Core.Accounting.Entities.Accounts.Sub;
using App.Domain.Core.Accounting.Entities.Enum;
using App.Domain.Core.Accounting.Entities.PMEList;
using App.Domain.Core.Accounting.Entities.Users;
using System.ComponentModel.DataAnnotations;

namespace App.Domain.Core.Accounting.Entities.payment
{
    public class Check
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        [Required]
        public string ChecNumber { get; set; }

        [Range(0.01, 100000000000.00, ErrorMessage = "The amount must be between 0.01 and 100,000,000,000.")]
        public decimal Amount { get; set; }
        public DateTime DuDate { get; set; }
        public string? Description { get; set; }
        public bool IsDeleted { get; set; }

        //*****************************************************


        public int BankId { get; set; }
        public Bank Banks { get; set; }

        public int? SubcategoryCostId { get; set; }
        public SubcategoryCost? SubCategorise { get; set; }

        public int? SubcategoryIncomeId { get; set; }
        public SubcategoryIncome? SubCategoryIncomes { get; set; }

        public int? MemderId { get; set; }
        public Member? Members { get; set; }

        public int? EventId { get; set; }
        public Event? Events { get; set; }

        public int? ProjectId { get; set; }
        public Project? Projects { get; set; }


        public Xxpens Xxpenses { get; set; }

        public int UserId { get; set; }
        public User Users { get; set; }


    }
}
