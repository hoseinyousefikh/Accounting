using App.Domain.Core.Accounting.DTO;
using App.Domain.Core.Accounting.Entities.AccountIn;
using App.Domain.Core.Accounting.Entities.Accounts;
using App.Domain.Core.Accounting.Entities.Accounts.Sub;
using App.Domain.Core.Accounting.Entities.Enum;
using System.ComponentModel.DataAnnotations;

namespace AccountingMVC.Models
{
    public class CriticismViewModel
    {
        [Required]
        public DateTime Date { get; set; }

        [Required]
        public DateTime Time { get; set; }

        [Required(ErrorMessage = "Amount is required.")]
        [Range(0.01, 100000000000.00, ErrorMessage = "The amount must be between 0.01 and 100,000,000,000.")]
        public decimal Amount { get; set; }

        public string? Description { get; set; }

        public int? SubcategoryCostId { get; set; }
        public int? MemberId { get; set; } = 0; 
        public int? EventId { get; set; } = 0; 
        public int? ProjectId { get; set; } = 0;

        [Required]
        public int UserId { get; set; }

        [Required]
        public int FromAccountId { get; set; }

        [Required(ErrorMessage = "Please select an expense type.")]
        public Xxpens Xxpenses { get; set; }

        public string? CategoryCostName { get; set; }
        public int? CategoryCostId { get; set; }
        public string? SubcategoryCostName { get; set; }

        public List<CategoryCost>? CategoryCosts { get; set; }
        public List<SubcategoryCost>? SubcategoryCosts { get; set; }
        public string? FromAccountName { get; set; }
        public int? FromAccountSubId { get; set; }
        public int? SubcategoryIncomeId { get; set; }
        public int? CategoryIncomeId { get; set; }
        public string? CategoryIncomeName { get; set; }
        public string? SubcategoryIncomeName { get; set; }
        public List<CategoryIncomeDto>? CategoryIncomes { get; set; }
        public List<SubcategoryIncomeDto>? SubcategoryIncomes { get; set; }
    }
}
