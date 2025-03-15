using App.Domain.Core.Accounting.Contract.Repositories.AccountIn;
using App.Domain.Core.Accounting.Contract.Repositories.Accounts.Sub;
using App.Domain.Core.Accounting.Contract.Repositories.payment;
using App.Domain.Core.Accounting.Contract.Repositories.PMEList;
using App.Domain.Core.Accounting.Contract.Repositories.Users;
using App.Domain.Core.Accounting.Contract.Services.payment;
using App.Domain.Core.Accounting.DTO;
using App.Domain.Core.Accounting.Entities.payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Accounting.Services.payment
{
    public class CriticismService: ICriticismService
    {

        private readonly ICriticismRepository _criticismsRepository;
        private readonly IFromAccountRepository _fromAccountRepository;
        private readonly IUserRepository _userRepository;
        private readonly ISubcategoryCostRepository _subcategoryCostRepository;
        private readonly ISubcategoryIncomeRepository _subcategoryIncomeRepository;
        private readonly IEventRepository _eventRepository;
        private readonly IProjectRepository _projectRepository;
        private readonly IMemberRepository _memberRepository;
        public CriticismService(
           ICriticismRepository criticismsRepository,
           IFromAccountRepository fromAccountRepository,
           IUserRepository userRepository,
           ISubcategoryCostRepository subcategoryCostRepository,
           ISubcategoryIncomeRepository subcategoryIncomeRepository,
           IEventRepository eventRepository,
           IProjectRepository projectRepository,
           IMemberRepository memberRepository)
        {
            _criticismsRepository = criticismsRepository;
            _fromAccountRepository = fromAccountRepository;
            _userRepository = userRepository;
            _subcategoryCostRepository = subcategoryCostRepository;
            _subcategoryIncomeRepository = subcategoryIncomeRepository;
            _eventRepository = eventRepository;
            _projectRepository = projectRepository;
            _memberRepository = memberRepository;
        }

        public async Task AddCriticismAsync(CriticismRequestDto criticismRequest)
        {
            var criticism = new Criticism
            {
                Date = criticismRequest.Date,
                Time = criticismRequest.Time,
                Amount = criticismRequest.Amount,
                Description = criticismRequest.Description,
                IsDeleted = false,
                SubcategoryCostId = criticismRequest.SubcategoryCostId,
                SubcategoryIncomeId = criticismRequest.SubcategoryIncomeId,
                MemderId = criticismRequest.MemderId,
                EventId = criticismRequest.EventId,
                ProjectId = criticismRequest.ProjectId,
                UserId = criticismRequest.UserId,
                FromAccountId = criticismRequest.FromAccountId,
                Xxpenses = criticismRequest.Xxpenses
            };

            await _criticismsRepository.AddCriticismAsync(criticism);
        }

    }
}

