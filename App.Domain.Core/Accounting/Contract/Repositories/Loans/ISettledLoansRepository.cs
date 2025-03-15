using App.Domain.Core.Accounting.Entities.Loans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Accounting.Contract.Repositories.Loans
{
    public interface ISettledLoansRepository
    {
        Task AddSettledLoans(SettledLoans settledLoan);
        Task UpdateSettledLoans(SettledLoans settledLoan);
        Task DeleteSettledLoans(int id);
        Task<List<SettledLoans>> GetAllSettledLoans();
        Task<SettledLoans> GetSettledLoansById(int id);
        Task<List<SettledLoans>> GetSettledLoansByUserId(int userId);
        Task<List<SettledLoans>> GetSettledLoansByTime(DateTime startTime, DateTime endTime);
        Task<List<SettledLoans>> GetSettledLoansByActive();
        Task<List<SettledLoans>> GetSettledLoansByNotActive();
    }
}
