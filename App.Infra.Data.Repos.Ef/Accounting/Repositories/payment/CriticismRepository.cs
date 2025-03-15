using App.Domain.Core.Accounting.Contract.Repositories.payment;
using App.Domain.Core.Accounting.Entities.Enum;
using App.Domain.Core.Accounting.Entities.payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Repos.Ef.Accounting.Repositories.payment
{
    public class CriticismRepository : ICriticismRepository
    {
        private readonly List<Criticism> _criticisms = new();

        public async Task AddCriticismAsync(Criticism criticism)
        {
            await Task.Run(() => _criticisms.Add(criticism));
        }

        public async Task UpdateCriticismAsync(Criticism criticism)
        {
            await Task.Run(() =>
            {
                var existing = _criticisms.Find(c => c.Id == criticism.Id);
                if (existing != null)
                {
                    existing.Date = criticism.Date;
                    existing.Amount = criticism.Amount;
                    existing.Description = criticism.Description;
                    existing.IsDeleted = criticism.IsDeleted;
                }
            });
        }

        public async Task DeleteCriticismAsync(int id)
        {
            await Task.Run(() =>
            {
                var criticism = _criticisms.Find(c => c.Id == id);
                if (criticism != null)
                {
                    criticism.IsDeleted = true;
                }
            });
        }

        public async Task<Criticism> GetCriticismByIdAsync(int id)
        {
            var x = await Task.Run(() => _criticisms.Find(c => c.Id == id));
            if (x != null)
            {
                return x;
            }
            throw new Exception("Is null");
        }

        public async Task<IEnumerable<Criticism>> GetCriticismByUserIdAsync(int userId)
        {
            return await Task.Run(() => _criticisms.FindAll(c => c.UserId == userId));
        }

        public async Task<IEnumerable<Criticism>> GetCriticismByMemberIdAsync(int memberId)
        {
            return await Task.Run(() => _criticisms.FindAll(c => c.MemderId == memberId));
        }

        public async Task<IEnumerable<Criticism>> GetCriticismByExpensAsync(Xxpens expensType)
        {
            return await Task.Run(() => _criticisms.FindAll(c => c.Xxpenses == expensType));
        }

        public async Task<IEnumerable<Criticism>> GetCriticismByDateAsync(DateTime date)
        {
            return await Task.Run(() => _criticisms.FindAll(c => c.Date.Date == date.Date));
        }

        public async Task<IEnumerable<Xxpens>> GetAllExpenseStatusesAsync()
        {
            return await Task.Run(() => (IEnumerable<Xxpens>)Enum.GetValues(typeof(Xxpens)));
        }
    }
}
