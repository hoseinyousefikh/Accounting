using App.Domain.Core.Accounting.Contract.Repositories.PMEList;
using App.Domain.Core.Accounting.Entities.PMEList;
using App.Infra.Data.Db.SqlServer.Ef.Accounting.DBContaxt;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Repos.Ef.Accounting.Repositories.PMEList
{
    public class EventRepository : IEventRepository
    {
        private readonly AppDbContext _context;

        public EventRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddEvent(Event eventEntity)
        {
            await _context.Events.AddAsync(eventEntity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEvent(Event eventEntity)
        {
            _context.Events.Update(eventEntity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEvent(int id)
        {
            var eventEntity = await _context.Events.FindAsync(id);
            if (eventEntity != null)
            {
                eventEntity.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Event> GetEventById(int id)
        {
            var x = await _context.Events
                .FirstOrDefaultAsync(e => e.Id == id && !e.IsDeleted);
            if (x != null)
            {

                return x;
            }
            throw new Exception("is null");
        }


        public async Task<List<Event>> GetEventByUserId(int userId)
        {
            return await _context.Events
                .Where(e => e.UserId == userId && !e.IsDeleted)
                .ToListAsync();
        }
    }
}
