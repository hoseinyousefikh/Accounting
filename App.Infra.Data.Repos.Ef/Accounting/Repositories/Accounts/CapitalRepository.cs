using App.Domain.Core.Accounting.Contract.Repositories.Accounts;
using App.Domain.Core.Accounting.Entities.Accounts;
using App.Infra.Data.Db.SqlServer.Ef.Accounting.DBContaxt;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Infra.Data.Repos.Ef.Accounting.Repositories.Accounts
{
    public class CapitalRepository : ICapitalRepository
    {
        private readonly AppDbContext _context;

        public CapitalRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        // Add a new Capital record asynchronously
        public async Task AddCapitalAsync(Capital capital)
        {
            if (capital == null)
                throw new ArgumentNullException(nameof(capital), "Capital cannot be null.");

            await _context.Capitals.AddAsync(capital);
            await _context.SaveChangesAsync();
        }

        // Update an existing Capital record asynchronously
        public async Task UpdateCapitalAsync(Capital capital)
        {
            if (capital == null)
                throw new ArgumentNullException(nameof(capital), "Capital cannot be null.");

            _context.Capitals.Update(capital);
            await _context.SaveChangesAsync();
        }

        // Soft delete a Capital record asynchronously by marking it as deleted
        public async Task DeleteCapitalAsync(int id)
        {
            var capital = await _context.Capitals.FindAsync(id);
            if (capital == null)
            {
                throw new KeyNotFoundException($"Capital with ID {id} not found.");
            }

            // You could choose to mark it as deleted instead of removing it from the database
            // capital.IsDeleted = true;
            // _context.Capitals.Update(capital);
            // await _context.SaveChangesAsync();

            _context.Capitals.Remove(capital); // If you want to physically delete it
            await _context.SaveChangesAsync();
        }

        // Retrieve all Capital records asynchronously
        public async Task<List<Capital>> GetAllCapitalAsync()
        {
            return await _context.Capitals
                .Where(c => !c.IsDeleted)  // Assuming soft delete is in place, add filter to exclude deleted records
                .ToListAsync();
        }

        // Get a specific Capital record by ID asynchronously
        public async Task<Capital> GetCapitalByIdAsync(int id)
        {
            var capital = await _context.Capitals
                .Where(c => c.Id == id && !c.IsDeleted)  // Ensure the capital is not marked as deleted
                .FirstOrDefaultAsync();

            if (capital == null)
            {
                throw new KeyNotFoundException($"Capital with ID {id} not found.");
            }

            return capital;
        }

        // Retrieve all Capital records for a specific user asynchronously
        public async Task<List<Capital>> GetCapitalByUserIdAsync(int userId)
        {
            return await _context.Capitals
                .Where(c => c.UserId == userId && !c.IsDeleted)  // Filter out deleted records if soft delete is used
                .ToListAsync();
        }
    }
}
