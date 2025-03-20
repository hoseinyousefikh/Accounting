using App.Domain.Core.Accounting.Contract.Repositories.payment;
using App.Domain.Core.Accounting.Contract.Services.payment;
using App.Domain.Core.Accounting.DTO;
using App.Domain.Core.Accounting.Entities.payment;
using App.Domain.Core.Accounting.Entities.PMEList;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Accounting.Services.payment
{
    public class CheckService : ICheckService
    {
        private readonly ICheckRepository _checkRepository;
        private readonly IMapper _mapper;


        public CheckService(ICheckRepository checkRepository, IMapper mapper)
        {
            _checkRepository = checkRepository;
            _mapper = mapper;
        }
        public async Task AddCheckAsync(CheckDto checkDto)
        {
            var check = _mapper.Map<Check>(checkDto);
            await _checkRepository.AddCheckAsync(check);
        }

    }
}
