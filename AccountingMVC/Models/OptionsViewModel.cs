using App.Domain.Core.Accounting.Entities.Accounts;
using App.Domain.Core.Accounting.Entities.Accounts.Sub;
using App.Domain.Core.Accounting.Entities.payment;

namespace AccountingMVC.Models
{
    public class OptionsViewModel
    {
        public List<SubcategoryIncome>? SubCategoryIncomeOptions { get; set; }
        public List<SubcategoryCost>? SubCategoryCostOptions { get; set; }

        public List<Creditors> CreditorsOptions { get; set; }  
        public List<Funds> FundOptions { get; set; }
        public List<Assets> AssetOptions { get; set; }
        public List<Bank> BankOptions { get; set; }
        public List<Debts> DebtorOptions { get; set; }
        public List<Persons> PersonOptions { get; set; }
        public List<Capital> CapitalOptions { get; set; }
    }
}
