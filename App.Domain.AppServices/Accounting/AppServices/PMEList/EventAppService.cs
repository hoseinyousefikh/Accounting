using App.Domain.Core.Accounting.Contract.AppServices.PMEList;
using App.Domain.Core.Accounting.Contract.Services.PMEList;
using App.Domain.Core.Accounting.DTO;
using App.Domain.Services.Accounting.Services.PMEList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices.Accounting.AppServices.PMEList
{
    public class EventAppService : IEventAppService
    {
        private readonly IEventService _eventService;
        public EventAppService(IEventService eventService)
        {
            _eventService = eventService;
        }
        public Task AddEventAsync(EventDto eventDto)
        {
            return _eventService.AddEventAsync(eventDto);
        }

        public Task<List<EventDto>> GetEventByUserIdAsync(int userId)
        {
            return _eventService.GetEventByUserIdAsync(userId);
        }
    }
}
