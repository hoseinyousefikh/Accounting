using App.Domain.Core.Accounting.DTO;
using App.Domain.Core.Accounting.Entities.Accounts;
using App.Domain.Core.Accounting.Entities.Accounts.Sub;
using App.Domain.Core.Accounting.Entities.Enum;
using System.ComponentModel.DataAnnotations;

namespace AccountingMVC.Models
{
    public class CheckViewModel
    {
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public DateTime Time { get; set; }
        [Required]
        public string ChecNumber { get; set; }

        [Required(ErrorMessage = "Amount is required.")]
        [Range(0.01, 100000000000.00, ErrorMessage = "The amount must be between 0.01 and 100,000,000,000.")]
        public decimal Amount { get; set; }

        [Required]
        public DateTime DuDate { get; set; }

        public string? Description { get; set; }

        public int? SubcategoryCostId { get; set; }
        public string? SubcategoryCostName { get; set; }

        public int? MemberId { get; set; }
        public int? EventId { get; set; }
        public int? ProjectId { get; set; }
        public string? CategoryCostName { get; set; }
        public int? CategoryCostId { get; set; }
        public List<CategoryCost>? CategoryCosts { get; set; }
        public List<SubcategoryCost>? SubcategoryCosts { get; set; }
        [Required]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Please select an expense type.")]
        public Xxpens Xxpenses { get; set; }

        [Required]
        public int BankId { get; set; }
        public string? BankName { get; set; }

        public int? SubcategoryIncomeId { get; set; }
        public int? CategoryIncomeId { get; set; }
        public string? CategoryIncomeName { get; set; }
        public string? SubcategoryIncomeName { get; set; }
        public List<CategoryIncomeDto>? CategoryIncomes { get; set; }
        public List<SubcategoryIncomeDto>? SubcategoryIncomes { get; set; }
    }
}
