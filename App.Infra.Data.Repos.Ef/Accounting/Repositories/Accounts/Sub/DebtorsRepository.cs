//using App.Domain.Core.Accounting.Contract.Repositories.Accounts.Sub;
//using App.Domain.Core.Accounting.Entities.Accounts.Sub;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace App.Infra.Data.Repos.Ef.Accounting.Repositories.Accounts.Sub
//{
//    public class DebtorsRepository : IDebtorsRepository
//    {
//        private readonly List<Debtors> _debtors;

//        public DebtorsRepository()
//        {
//            _debtors = new List<Debtors>();
//        }

//        public async Task AddDebtorsAsync(Debtors debtor)
//        {
//            await Task.Run(() => _debtors.Add(debtor));
//        }

//        public async Task UpdateDebtorsAsync(Debtors debtor)
//        {
//            await Task.Run(() =>
//            {
//                var existingDebtor = _debtors.FirstOrDefault(d => d.Id == debtor.Id);
//                if (existingDebtor != null)
//                {
//                    existingDebtor.Amount = debtor.Amount;
//                    existingDebtor.Descriptions = debtor.Descriptions;
//                    existingDebtor.UserId = debtor.UserId;
//                    existingDebtor.Users = debtor.Users;
//                }
//            });
//        }

//        public async Task DeleteDebtorsAsync(int id)
//        {
//            await Task.Run(() =>
//            {
//                var debtor = _debtors.FirstOrDefault(d => d.Id == id);
//                if (debtor != null)
//                {
//                    _debtors.Remove(debtor);
//                }
//            });
//        }

//        public async Task<Debtors> GetDebtorsByIdAsync(int id)
//        {
//            var x = await Task.Run(() => _debtors.FirstOrDefault(d => d.Id == id));
//            if (x != null)
//            {
//                return x;
//            }
//            throw new Exception("Is null");
//        }

//        public async Task<List<Debtors>> GetDebtorsByUserIdAsync(int userId)
//        {
//            return await Task.Run(() => _debtors.Where(d => d.UserId == userId).ToList());
//        }
//    }
//}
