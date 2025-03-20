using App.Domain.Core.Accounting.Entities.Accounts;
using App.Domain.Core.Accounting.Entities.payment;

namespace AccountingMVC.Models
{
    public class OptionsViewModel
    {
        public List<CategoryIncome> IncomeOptions { get; set; }
        public List<Funds> FundOptions { get; set; }
        public List<Assets> AssetOptions { get; set; }
        public List<Bank> BankOptions { get; set; }
        public List<Debts> DebtorOptions { get; set; }
        public List<Criticism> OtherOptions { get; set; }
        public List<CategoryCost> CreditorOptions { get; set; }
        public List<Persons> PersonOptions { get; set; }
        public List<Capital> CapitalOptions { get; set; }
    }
}
