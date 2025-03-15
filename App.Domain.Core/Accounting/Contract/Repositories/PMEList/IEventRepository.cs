using App.Domain.Core.Accounting.Entities.PMEList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Accounting.Contract.Repositories.PMEList
{
    public interface IEventRepository
    {
        Task AddEvent(Event eventEntity);
        Task UpdateEvent(Event eventEntity);
        Task DeleteEvent(int id);
        Task<Event> GetEventById(int id);
        Task<List<Event>> GetEventByUserId(int userId);
    }
}
