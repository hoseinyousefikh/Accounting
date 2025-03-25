using App.Domain.Core.Accounting.Entities.Accounts;
using App.Domain.Core.Accounting.Entities.Accounts.Sub;
using App.Domain.Core.Accounting.Entities.payment;
using System.Security.Principal;

namespace App.Domain.Core.Accounting.Entities.AccountIn
{
    public class FromAccount
    {
        public int Id { get; set; }

        public int? AssetsId { get; set; }
        public int? BankId { get; set; }
        public int? CapitalId { get; set; }
        public int? DebtsId { get; set; }
        public int? FundsId { get; set; }
        public int? PersonsId { get; set; }
        public int? CreditorsId { get; set; }
        public int? SubCategoryIncomeId { get; set; }


        public Assets? Asset { get; set; }
        public Bank? Banks { get; set; }
        public Capital? Capitals { get; set; }
        public Debts? Debt { get; set; }
        public Funds? Fund { get; set; }
        public Persons? Person { get; set; }
        public Creditors? Creditors{ get; set; }
        public SubcategoryIncome? SubcategoryIncomes { get; set; }

    }
}