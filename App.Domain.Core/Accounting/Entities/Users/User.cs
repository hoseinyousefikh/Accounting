using App.Domain.Core.Accounting.Entities.Accounts;
using App.Domain.Core.Accounting.Entities.Accounts.Sub;
using App.Domain.Core.Accounting.Entities.Budgetings;
using App.Domain.Core.Accounting.Entities.Loans;
using App.Domain.Core.Accounting.Entities.payment;
using App.Domain.Core.Accounting.Entities.PMEList;
using App.Domain.Core.Accounting.Entities.Reports;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace App.Domain.Core.Accounting.Entities.Users
{
    public class User : IdentityUser<int>
    {
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        public bool IsActive { get; set; }
        public bool? IsDeleted { get; set; } = false;
        public bool IsBloked { get; set; } = false;
        public int RoleId { get; set; }

        public List<Contacts> Contacts { get; set; }
        public List<IncomeList> IncomeLists { get; set; }
        public List<ListExpenses> ListExpenses { get; set; }
        public List<Event> Events { get; set; }
        public List<Member> Members { get; set; }
        public List<Project> Projects { get; set; }
        public List<Check> Checks { get; set; }
        public List<Criticism> Criticisms { get; set; }
        public List<SettledLoans> SettledLoans { get; set; }
        public List<Budgeting> Budgetings { get; set; }
        public ICollection<SubcategoryCost> SubcategoryCosts { get; set; }
        public List<SubcategoryIncome> SubcategoryIncomes { get; set; }
        public List<Debtors> Debtors { get; set; }
        public List<Creditors> Creditorses { get; set; }
        public List<AddDbts> AddDbts { get; set; }
        public List<AddCapital> AddCapitals { get; set; }
        public List<AddAssets> AddAssets { get; set; }
        public List<Assets> Assetses { get; set; }
        public List<Bank> Banks { get; set; }
        public List<Capital> Capitals { get; set; }
        public List<CategoryCost> CategoryCosts { get; set; }
        public List<CategoryIncome> CategoryIncomes { get; set; }
        public List<Debts> Debtses { get; set; }
        public List<Funds> Fundses { get; set; }
        public List<Persons> Persons { get; set; }
    }
}
