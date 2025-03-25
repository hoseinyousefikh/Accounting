using App.Domain.Core.Accounting.Entities.AccountIn;
using App.Domain.Core.Accounting.Entities.Accounts;
using App.Domain.Core.Accounting.Entities.Accounts.Sub;
using App.Domain.Core.Accounting.Entities.Budgetings;
using App.Domain.Core.Accounting.Entities.Loans;
using App.Domain.Core.Accounting.Entities.payment;
using App.Domain.Core.Accounting.Entities.PMEList;
using App.Domain.Core.Accounting.Entities.Reports;
using App.Domain.Core.Accounting.Entities.Users;
using App.Infra.Data.Db.SqlServer.Ef.Accounting.Configoration.AccountIn;
using App.Infra.Data.Db.SqlServer.Ef.Accounting.Configoration.Accounts;
using App.Infra.Data.Db.SqlServer.Ef.Accounting.Configoration.Accounts.Sub;
using App.Infra.Data.Db.SqlServer.Ef.Accounting.Configoration.Budgetings;
using App.Infra.Data.Db.SqlServer.Ef.Accounting.Configoration.Loans;
using App.Infra.Data.Db.SqlServer.Ef.Accounting.Configoration.payment;
using App.Infra.Data.Db.SqlServer.Ef.Accounting.Configoration.PMEList;
using App.Infra.Data.Db.SqlServer.Ef.Accounting.Configoration.Reports;
using App.Infra.Data.Db.SqlServer.Ef.Accounting.Configoration.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.Data.Db.SqlServer.Ef.Accounting.DBContaxt
{
    public class AppDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public DbSet<Contacts> Contacts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<IncomeList> IncomeLists { get; set; }
        public DbSet<ListExpenses> ListExpenses { get; set; }
        public DbSet<SettledLoans> SettledLoans { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Check> Checks { get; set; }
        public DbSet<Criticism> Criticisms { get; set; }
        public DbSet<Budgeting> Budgetings { get; set; }
        public DbSet<FromAccount> FromAccounts { get; set; }
        public DbSet<Assets> Assets { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<Capital> Capitals { get; set; }
        public DbSet<CategoryCost> CategoryCosts { get; set; }
        public DbSet<CategoryIncome> CategoryIncomes { get; set; }
        public DbSet<Debts> Debts { get; set; }
        public DbSet<Funds> Funds { get; set; }
        public DbSet<Persons> Persons { get; set; }
       
        public DbSet<Creditors> Creditorses { get; set; }
        public DbSet<Debtors> Debtorses { get; set; }
        public DbSet<SubcategoryCost> SubcategoryCosts { get; set; }
        public DbSet<SubcategoryIncome> SubcategoryIncomes { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IdentityRole<int>>().HasData(
           new IdentityRole<int> { Id = 1, Name = "Admin", NormalizedName = "ADMIN" },
           new IdentityRole<int> { Id = 2, Name = "Employee", NormalizedName = "EMPLOYEE" }
       );

            modelBuilder.Entity<IdentityUserRole<int>>().HasData(
                new IdentityUserRole<int> { UserId = 1, RoleId = 1 },
                new IdentityUserRole<int> { UserId = 2, RoleId = 2}
            );
            modelBuilder.ApplyConfiguration(new ContactsConfiguration());
            modelBuilder.ApplyConfiguration(new PersonsConfiguration());

            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new IncomeListConfiguration());
            modelBuilder.ApplyConfiguration(new ListExpensesConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryIncomeConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryCostConfiguration());
            modelBuilder.ApplyConfiguration(new SubcategoryIncomeConfiguration());
            modelBuilder.ApplyConfiguration(new SubcategoryCostConfiguration());
            modelBuilder.ApplyConfiguration(new SettledLoansConfiguration());
            modelBuilder.ApplyConfiguration(new ProjectConfiguration());
            modelBuilder.ApplyConfiguration(new MemberConfiguration());
            modelBuilder.ApplyConfiguration(new FundsConfiguration());
            modelBuilder.ApplyConfiguration(new FromAccountConfiguration());
            modelBuilder.ApplyConfiguration(new EventConfiguration());
            modelBuilder.ApplyConfiguration(new DebtsConfiguration());
            modelBuilder.ApplyConfiguration(new DebtorsConfiguration());
            modelBuilder.ApplyConfiguration(new CriticismConfiguration());
            modelBuilder.ApplyConfiguration(new CreditorsConfiguration());
            modelBuilder.ApplyConfiguration(new CheckConfiguration());
          
            modelBuilder.ApplyConfiguration(new CapitalConfiguration());
            modelBuilder.ApplyConfiguration(new BudgetingConfiguration());
            modelBuilder.ApplyConfiguration(new BankConfiguration());
            modelBuilder.ApplyConfiguration(new AssetsConfiguration());
           
        }
    }

}
