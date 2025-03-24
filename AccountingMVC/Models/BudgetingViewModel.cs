using App.Domain.Core.Accounting.DTO;
using App.Domain.Core.Accounting.Entities.Accounts;
using App.Domain.Core.Accounting.Entities.Accounts.Sub;
using App.Domain.Core.Accounting.Entities.Enum;
using System.ComponentModel.DataAnnotations;

namespace AccountingMVC.Models
{
    public class BudgetingViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "لطفاً بازه زمانی را انتخاب کنید.")]
        public Timing Timings { get; set; }

        [Required(ErrorMessage = "لطفاً نوع هزینه را انتخاب کنید.")]
        public Xxpens Xxpenses { get; set; }

        [Required(ErrorMessage = "لطفاً حداقل مقدار را وارد کنید.")]
        [Range(0.01, 100000000000.00, ErrorMessage = "مقدار باید بین 0.01 تا 100,000,000,000 باشد.")]
        public decimal MinAmount { get; set; }

        [Required(ErrorMessage = "لطفاً حداکثر مقدار را وارد کنید.")]
        [Range(0.01, 100000000000.00, ErrorMessage = "مقدار باید بین 0.01 تا 100,000,000,000 باشد.")]
        public decimal MaxAmount { get; set; }
        public int? SubCategoryCostId { get; set; }
        public string? SubcategoryCostName { get; set; }


        public int? SubCategoryIncomeId { get; set; }
        public string? SubcategoryIncomeName { get; set; }


        public int? CategoryIncomeId { get; set; }
        public string? CategoryIncomeName { get; set; }

        public string? CategoryCostName { get; set; }
        public int? CategoryCostId { get; set; }
        public  int UserId { get; set; }
        public List<CategoryCost>? CategoryCosts { get; set; }
        public List<SubcategoryCost>? SubcategoryCosts { get; set; }
        public List<CategoryIncomeDto>? CategoryIncomes { get; set; }
        public List<SubcategoryIncomeDto>? SubcategoryIncomes { get; set; }

        [Required(ErrorMessage = "لطفاً تاریخ شروع را انتخاب کنید.")]
        [DataType(DataType.Date)]
        public DateTime FDate { get; set; }

        [Required(ErrorMessage = "لطفاً تاریخ پایان را انتخاب کنید.")]
        [DataType(DataType.Date)]
        public DateTime TDate { get; set; }
    }
}
