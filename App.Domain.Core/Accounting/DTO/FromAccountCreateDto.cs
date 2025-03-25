namespace App.Domain.Core.Accounting.DTO
{
    public class FromAccountCreateDto
    {
        public int? AssetsId { get; set; }
        public int? BankId { get; set; }
        public int? CapitalId { get; set; }
        public int? DebtsId { get; set; }
        public int? FundsId { get; set; }
        public int? PersonsId { get; set; }
        public int? CreditorsId { get; set; }  
        public int? SubCategoryIncomeId { get; set; }
        public int? SubCategoryCostId { get; set; }

    }
}
