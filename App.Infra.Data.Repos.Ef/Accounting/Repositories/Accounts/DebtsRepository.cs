using App.Domain.Core.Accounting.Contract.Repositories.Accounts;
using App.Domain.Core.Accounting.Entities.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Repos.Ef.Accounting.Repositories.Accounts
{
    public class DebtsRepository : IDebtsRepository
    {
        private readonly List<Debts> _debts;

        public DebtsRepository()
        {
            _debts = new List<Debts>();
        }

        public async Task AddDebtsAsync(Debts debt)
        {
            _debts.Add(debt);
            await Task.CompletedTask;
        }

        public async Task UpdateDebtsAsync(Debts debt)
        {
            var existingDebt = _debts.FirstOrDefault(d => d.Id == debt.Id);
            if (existingDebt != null)
            {
                existingDebt.Name = debt.Name;
                existingDebt.IsPublic = debt.IsPublic;
                existingDebt.UserId = debt.UserId;
                existingDebt.Users = debt.Users;
                existingDebt.AddDbts = debt.AddDbts;
            }
            await Task.CompletedTask;
        }

        public async Task DeleteDebtsAsync(int id)
        {
            var debt = _debts.FirstOrDefault(d => d.Id == id);
            if (debt != null)
            {
                debt.IsDeleted = true;
            }
            await Task.CompletedTask;
        }

        public async Task<Debts> GetDebtsByIdAsync(int id)
        {
            var x = await Task.FromResult(_debts.FirstOrDefault(d => d.Id == id && !d.IsDeleted));
            if (x != null)
            {
                return x;
            }
            throw new Exception("Is null");
        }

        public async Task<List<Debts>> GetDebtsByUserIdAsync(int userId)
        {
            return await Task.FromResult(_debts.Where(d => d.UserId == userId && !d.IsDeleted).ToList());
        }
    }
}
