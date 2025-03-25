using App.Domain.Core.Accounting.Contract.Repositories.AccountIn;
using App.Domain.Core.Accounting.Contract.Repositories.Accounts;
using App.Domain.Core.Accounting.Contract.Repositories.Accounts.Sub;
using App.Domain.Core.Accounting.Contract.Services.AccountIn;
using App.Domain.Core.Accounting.DTO;
using App.Domain.Core.Accounting.Entities.AccountIn;
using App.Domain.Core.Accounting.Entities.Accounts;
using App.Domain.Core.Accounting.Entities.Accounts.Sub;

public class FromAccountService : IFromAccountService
{
    private readonly IFromAccountRepository _fromAccountRepository;
    private readonly IAssetsRepository _assetRepository;
    private readonly IBankRepository _bankRepository;
    private readonly ICapitalRepository _capitalRepository;
    private readonly IDebtsRepository _debtRepository;
    private readonly IFundsRepository _fundRepository;
    private readonly IPersonsRepository _personRepository;
    private readonly ICreditorsRepository _creditorsRepository;
    private readonly ISubcategoryIncomeRepository _subcategoryIncomeRepository;

    public FromAccountService(
        IFromAccountRepository fromAccountRepository,
        IAssetsRepository assetRepository,
        IBankRepository bankRepository,
        ICapitalRepository capitalRepository,
        IDebtsRepository debtRepository,
        IFundsRepository fundRepository,
        IPersonsRepository personRepository,
        ICreditorsRepository creditorsRepository,
        ISubcategoryIncomeRepository subcategoryIncomeRepository)
    {
        _fromAccountRepository = fromAccountRepository;
        _assetRepository = assetRepository;
        _bankRepository = bankRepository;
        _capitalRepository = capitalRepository;
        _debtRepository = debtRepository;
        _fundRepository = fundRepository;
        _personRepository = personRepository;
        _creditorsRepository = creditorsRepository;
        _subcategoryIncomeRepository = subcategoryIncomeRepository;
    }

    public async Task SubtractAmountFromAccountAsync(int fromAccountId, decimal amount)
    {
        if (fromAccountId <= 0)
            throw new ArgumentException("Invalid FromAccountId");

        if (amount <= 0)
            throw new ArgumentException("Amount must be greater than zero");

        var fromAccount = await _fromAccountRepository.GetFromAccountByIdAsync(fromAccountId);

        if (fromAccount.AssetsId.HasValue)
        {
            var asset = await _assetRepository.GetAssetsByIdAsync(fromAccount.AssetsId.Value);
            if (asset.Amount >= amount)
            {
                asset.Amount -= amount;
                await _assetRepository.UpdateAssetsAsync(asset);
            }
            else
            {
                throw new InvalidOperationException("Insufficient balance in Assets.");
            }
        }
        else if (fromAccount.BankId.HasValue)
        {
            var bank = await _bankRepository.GetBankByIdAsync(fromAccount.BankId.Value);
            if (bank.Amount >= amount)
            {
                bank.Amount -= amount;
                await _bankRepository.UpdateBankAsync(bank);
            }
            else
            {
                throw new InvalidOperationException("Insufficient balance in Bank.");
            }
        }
        else if (fromAccount.CapitalId.HasValue)
        {
            var capital = await _capitalRepository.GetCapitalByIdAsync(fromAccount.CapitalId.Value);
            if (capital.Amount >= amount)
            {
                capital.Amount -= amount;
                await _capitalRepository.UpdateCapitalAsync(capital);
            }
            else
            {
                throw new InvalidOperationException("Insufficient balance in Capital.");
            }
        }
        else if (fromAccount.DebtsId.HasValue)
        {
            var debt = await _debtRepository.GetDebtsByIdAsync(fromAccount.DebtsId.Value);
            if (debt.Amount >= amount)
            {
                debt.Amount -= amount;
                await _debtRepository.UpdateDebtsAsync(debt);
            }
            else
            {
                throw new InvalidOperationException("Insufficient balance in Debts.");
            }
        }
        else if (fromAccount.FundsId.HasValue)
        {
            var fund = await _fundRepository.GetFundsByIdAsync(fromAccount.FundsId.Value);
            if (fund.Amount >= amount)
            {
                fund.Amount -= amount;
                await _fundRepository.UpdateFundsAsync(fund);
            }
            else
            {
                throw new InvalidOperationException("Insufficient balance in Funds.");
            }
        }
        else if (fromAccount.PersonsId.HasValue)
        {
            var person = await _personRepository.GetPersonsById(fromAccount.PersonsId.Value);
            if (person.Amount >= amount)
            {
                person.Amount -= amount;
                await _personRepository.UpdatePersons(person);
            }
            else
            {
                throw new InvalidOperationException("Insufficient balance in Persons.");
            }
        }
        else if (fromAccount.CreditorsId.HasValue)
        {
            var creditors = await _creditorsRepository.GetCreditorsByIdAsync(fromAccount.CreditorsId.Value);
            if (creditors.Amount >= amount)
            {
                creditors.Amount -= amount;
                await _creditorsRepository.UpdateCreditorsAsync(creditors);
            }
            else
            {
                throw new InvalidOperationException("Insufficient balance in Creditors.");
            }
        }
        else if (fromAccount.SubCategoryIncomeId.HasValue)
        {
            var subcategoryIncome = await _subcategoryIncomeRepository.GetBySubCatIncomeIdAsync(fromAccount.SubCategoryIncomeId.Value);
            if (subcategoryIncome.Amount >= amount)
            {
                subcategoryIncome.Amount -= amount;
                await _subcategoryIncomeRepository.UpdateSubCatIncomeAsync(subcategoryIncome);
            }
            else
            {
                throw new InvalidOperationException("Insufficient balance in Subcategory Income.");
            }
        }
        else
        {
            throw new InvalidOperationException("No related entity found in the FromAccount.");
        }
    }

    public async Task<int> AddFromAccountAsync(FromAccountCreateDto fromAccountCreateDto)
    {
        var fromAccount = new FromAccount
        {
            AssetsId = fromAccountCreateDto.AssetsId,
            BankId = fromAccountCreateDto.BankId,
            CapitalId = fromAccountCreateDto.CapitalId,
            DebtsId = fromAccountCreateDto.DebtsId,
            FundsId = fromAccountCreateDto.FundsId,
            PersonsId = fromAccountCreateDto.PersonsId,
            CreditorsId = fromAccountCreateDto.CreditorsId,
            SubCategoryIncomeId = fromAccountCreateDto.SubCategoryIncomeId
        };

        return await _fromAccountRepository.AddFromAccountAsync(fromAccount);
    }

    public async Task<List<Assets>> GetAllAssetsAsync()
    {
        return await _fromAccountRepository.GetAllAssetsAsync();
    }

    public async Task<List<Bank>> GetAllBanksAsync()
    {
        return await _fromAccountRepository.GetAllBanksAsync();
    }

    public async Task<List<Capital>> GetAllCapitalsAsync()
    {
        return await _fromAccountRepository.GetAllCapitalsAsync();
    }

    public async Task<List<Creditors>> GetAllCreditorsAsync()
    {
        return await _fromAccountRepository.GetAllCreditorsAsync();
    }

    public async Task<List<Debts>> GetAllDebtsAsync()
    {
        return await _fromAccountRepository.GetAllDebtsAsync();
    }

    public async Task<List<Funds>> GetAllFundsAsync()
    {
        return await _fromAccountRepository.GetAllFundsAsync();
    }

    public async Task<List<Persons>> GetAllPersonsAsync()
    {
        return await _fromAccountRepository.GetAllPersonsAsync();
    }

    public async Task<List<SubcategoryIncome>> GetAllSubCategoryIncomesAsync()
    {
        return await _fromAccountRepository.GetAllSubCategoryIncomesAsync();
    }
}
