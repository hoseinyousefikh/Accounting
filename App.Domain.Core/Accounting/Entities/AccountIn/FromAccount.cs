using App.Domain.Core.Accounting.Entities.Accounts;
using App.Domain.Core.Accounting.Entities.payment;

namespace App.Domain.Core.Accounting.Entities.AccountIn
{
    public class FromAccount
    {
        public int Id { get; set; }

        public int? AssetsId { get; set; }
        public int? BankId { get; set; }
        public int? CapitalId { get; set; }
        public int? CategoryCostId { get; set; }
        public int? CategoryIncomeId { get; set; }
        public int? DebtsId { get; set; }
        public int? FundsId { get; set; }
        public int? PersonsId { get; set; }
        public int? CriticismId { get; set; }



        public Assets? Asset { get; set; }
        public Bank? Banks { get; set; }
        public Capital? Capitals { get; set; }
        public CategoryCost? CategoryCosts { get; set; }
        public CategoryIncome? CategoryIncomes { get; set; }
        public Debts? Debt { get; set; }
        public Funds? Fund { get; set; }
        public Persons? Person { get; set; }
        public Criticism? Criticisms { get; set; }
    }
}