using App.Domain.AppServices.Accounting.AppServices;
using App.Domain.AppServices.Accounting.AppServices.AccountIn;
using App.Domain.AppServices.Accounting.AppServices.Accounts;
using App.Domain.AppServices.Accounting.AppServices.Accounts.Sub;
using App.Domain.AppServices.Accounting.AppServices.Budgetings;
using App.Domain.AppServices.Accounting.AppServices.payment;
using App.Domain.AppServices.Accounting.AppServices.PMEList;
using App.Domain.AppServices.Accounting.AppServices.Reports;
using App.Domain.Core.Accounting.Contract.AppServices;
using App.Domain.Core.Accounting.Contract.AppServices.AccountIn;
using App.Domain.Core.Accounting.Contract.AppServices.Accounts;
using App.Domain.Core.Accounting.Contract.AppServices.Accounts.Sub;
using App.Domain.Core.Accounting.Contract.AppServices.Budgetings;
using App.Domain.Core.Accounting.Contract.AppServices.payment;
using App.Domain.Core.Accounting.Contract.AppServices.PMEList;
using App.Domain.Core.Accounting.Contract.AppServices.Reports;
using App.Domain.Core.Accounting.Contract.Repositories.AccountIn;
using App.Domain.Core.Accounting.Contract.Repositories.Accounts;
using App.Domain.Core.Accounting.Contract.Repositories.Accounts.Sub;
using App.Domain.Core.Accounting.Contract.Repositories.Budgetings;
using App.Domain.Core.Accounting.Contract.Repositories.Loans;
using App.Domain.Core.Accounting.Contract.Repositories.payment;
using App.Domain.Core.Accounting.Contract.Repositories.PMEList;
using App.Domain.Core.Accounting.Contract.Repositories.Reports;
using App.Domain.Core.Accounting.Contract.Repositories.Users;
using App.Domain.Core.Accounting.Contract.Services;
using App.Domain.Core.Accounting.Contract.Services.AccountIn;
using App.Domain.Core.Accounting.Contract.Services.Accounts;
using App.Domain.Core.Accounting.Contract.Services.Budgetings;
using App.Domain.Core.Accounting.Contract.Services.payment;
using App.Domain.Core.Accounting.Contract.Services.PMEList;
using App.Domain.Core.Accounting.Contract.Services.Reports;
using App.Domain.Core.Accounting.Entities.Users;
using App.Domain.Core.Accounting.Maper;
using App.Domain.Services.Accounting.Services;
using App.Domain.Services.Accounting.Services.AccountIn;
using App.Domain.Services.Accounting.Services.Accounts;
using App.Domain.Services.Accounting.Services.Accounts.Sub;
using App.Domain.Services.Accounting.Services.Budgetings;
using App.Domain.Services.Accounting.Services.payment;
using App.Domain.Services.Accounting.Services.PMEList;
using App.Domain.Services.Accounting.Services.Reports;
using App.Infra.Data.Db.SqlServer.Ef.Accounting.DBContaxt;
using App.Infra.Data.Repos.Ef.Accounting.Repositories.AccountIn;
using App.Infra.Data.Repos.Ef.Accounting.Repositories.Accounts;
using App.Infra.Data.Repos.Ef.Accounting.Repositories.Accounts.Sub;
using App.Infra.Data.Repos.Ef.Accounting.Repositories.Budgetings;
using App.Infra.Data.Repos.Ef.Accounting.Repositories.Loans;
using App.Infra.Data.Repos.Ef.Accounting.Repositories.payment;
using App.Infra.Data.Repos.Ef.Accounting.Repositories.PMEList;
using App.Infra.Data.Repos.Ef.Accounting.Repositories.Reports;
using App.Infra.Data.Repos.Ef.Accounting.Repositories.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("AppDbContext");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddIdentity<User, IdentityRole<int>>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;

    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);

}).AddRoles<IdentityRole<int>>()
  .AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddScoped<AppDbContext>();
builder.Services.AddDistributedMemoryCache();  
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); 
    options.Cookie.HttpOnly = true; 
    options.Cookie.IsEssential = true; 
});


builder.Services.AddAutoMapper(typeof(ProjectProfile));  

//******************************************************************************
builder.Services.AddScoped<IFromAccountRepository, FromAccountRepository>();
builder.Services.AddScoped<IAddAssetsRepository, AddAssetsRepository>();
builder.Services.AddScoped<IAddCapitalRepository, AddCapitalRepository>();
builder.Services.AddScoped<IAddDbtsRepository, AddDbtsRepository>();
builder.Services.AddScoped<ICreditorsRepository, CreditorsRepository>();
builder.Services.AddScoped<IDebtorsRepository, DebtorsRepository>();
builder.Services.AddScoped<ISubcategoryCostRepository, SubcategoryCostRepository>();
builder.Services.AddScoped<ISubcategoryIncomeRepository, SubcategoryIncomeRepository>();
builder.Services.AddScoped<IAssetsRepository, AssetsRepository>();
builder.Services.AddScoped<IBankRepository, BankRepository>();
builder.Services.AddScoped<ICapitalRepository, CapitalRepository>();
builder.Services.AddScoped<ICategoryCostRepository, CategoryCostRepository>();
builder.Services.AddScoped<ICategoryIncomeRepository, CategoryIncomeRepository>();
builder.Services.AddScoped<IDebtsRepository, DebtsRepository>();
builder.Services.AddScoped<IFundsRepository, FundsRepository>();
builder.Services.AddScoped<IPersonsRepository, PersonsRepository>();
builder.Services.AddScoped<IBudgetingRepository, BudgetingRepository>();
builder.Services.AddScoped<ISettledLoansRepository, SettledLoansRepository>();
builder.Services.AddScoped<ICheckRepository, CheckRepository>();
builder.Services.AddScoped<ICriticismRepository, CriticismRepository>();
builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<IMemberRepository, MemberRepository>();
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();


builder.Services.AddScoped<IIncomeListRepository, IncomeListRepository>();
builder.Services.AddScoped<IListExpensesRepository, ListExpensesRepository>();


builder.Services.AddScoped<IContactsRepository, ContactsRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
//*************************************************************************
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IIncomeListService, IncomeListService>();
builder.Services.AddScoped<IListExpensesService, ListExpensesService>();
builder.Services.AddScoped<ICriticismService, CriticismService>();
builder.Services.AddScoped<ICategoryCostService, CategoryCostService>();
builder.Services.AddScoped<ISubCategoryCostService, SubCategoryCostService>();
builder.Services.AddScoped<IFromAccountService, FromAccountService>();
builder.Services.AddScoped<IMemberService, MemberService>();
builder.Services.AddScoped<IEventService, EventService>();


builder.Services.AddScoped<IProjectAppService, ProjectAppService>();
builder.Services.AddScoped<IBankAppService, BankAppService>();
builder.Services.AddScoped<ICheckAppService, CheckAppService>();
builder.Services.AddScoped<ISubcategoryIncomeAppService, SubcategoryIncomeAppService>();
builder.Services.AddScoped<ICategoryIncomeAppService, CategoryIncomeAppService>();
builder.Services.AddScoped<IFundsService, FundsService>();
builder.Services.AddScoped<IBudgetingService, BudgetingService>();


//*************************************************************************
builder.Services.AddScoped<IUserAppService, UserAppService>();
builder.Services.AddScoped<IIncomeListAppService, IncomeListAppService>();
builder.Services.AddScoped<IListExpensesAppService, ListExpensesAppService>();
builder.Services.AddScoped<ICriticismAppService, CriticismAppService>();
builder.Services.AddScoped<ICategoryCostAppService, CategoryCostAppService>();
builder.Services.AddScoped<ISubCategoryCostAppService, SubCategoryCostAppService>();
builder.Services.AddScoped<IFromAccountAppService, FromAccountAppService>();
builder.Services.AddScoped<IMemberAppService, MemberAppService>();
builder.Services.AddScoped<IEventAppService, EventAppService>();
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<IBankService, BankService>();
builder.Services.AddScoped<ICheckService, CheckService>();
builder.Services.AddScoped<ISubcategoryIncomeService, SubcategoryIncomeService>();
builder.Services.AddScoped<ICategoryIncomeService, CategoryIncomeService>();
builder.Services.AddScoped<IFundsAppService, FundsAppService>();
builder.Services.AddScoped<IBudgetingAppService, BudgetingAppService>();








// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseSession();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Authentication}/{action=Login}/{id?}");

app.Run();
