using App.Domain.Core.Accounting.Contract.Repositories.PMEList;
using App.Domain.Core.Accounting.Contract.Services.PMEList;
using App.Domain.Core.Accounting.DTO;
using App.Domain.Core.Accounting.Entities.PMEList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Accounting.Services.PMEList
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;

        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task AddEventAsync(EventDto eventDto)
        {
            var eventEntity = new Event
            {
                Name = eventDto.Name,
                Description = eventDto.Description,
                IsDeleted = false, 
                UserId = eventDto.UserId
            };

            await _eventRepository.AddEvent(eventEntity);
        }
        public async Task<List<EventDto>> GetEventByUserIdAsync(int userId)
        {
            var events = await _eventRepository.GetEventByUserId(userId);
            return events.Select(e => new EventDto
            {
                Id =e.Id,
                Name = e.Name,
                Description = e.Description,
                UserId = e.UserId
            }).ToList();
        }

    }
}
