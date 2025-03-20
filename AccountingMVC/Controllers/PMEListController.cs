using AccountingMVC.Models;
using App.Domain.AppServices.Accounting.AppServices.PMEList;
using App.Domain.Core.Accounting.Contract.AppServices.PMEList;
using App.Domain.Core.Accounting.Contract.Services.PMEList;
using App.Domain.Core.Accounting.DTO;
using App.Domain.Services.Accounting.Services.PMEList;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AccountingMVC.Controllers
{
    public class PMEListController : Controller
    {
        private readonly IMemberAppService _memberAppService;
        private readonly IEventAppService _eventAppService;
        private readonly IProjectAppService _projectAppService;
        public PMEListController(IMemberAppService memberAppService, IEventAppService eventAppService, IProjectAppService projectAppService)
        {
            _memberAppService = memberAppService;
            _eventAppService = eventAppService;
            _projectAppService = projectAppService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MemberViewModel member)
        {
            if (ModelState.IsValid)
            {
                var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (int.TryParse(userIdClaim, out int userId))
                {
                    var memberDto = new MemberDto
                    {
                        Name = member.Name,
                        Description = member.Description,
                        UserId = userId
                    };

                    await _memberAppService.AddMemberAsync(memberDto);
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError(string.Empty, "Unable to retrieve User ID from claims.");
            }
            return View(member);
        }


        [HttpGet]
        public IActionResult CreateEvent()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateEvent(EventViewModel eventViewModel)
        {
            if (ModelState.IsValid)
            {
                var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (int.TryParse(userIdClaim, out int userId))
                {
                    var eventDto = new EventDto
                    {
                        Name = eventViewModel.Name,
                        Description = eventViewModel.Description,
                        UserId = userId
                    };

                    await _eventAppService.AddEventAsync(eventDto);
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError(string.Empty, "Unable to retrieve User ID from claims.");
            }

            return View(eventViewModel);
        }

        [HttpGet]
        public IActionResult CreateProject()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProject(ProjectViewModel projectViewModel)
        {
            if (ModelState.IsValid)
            {
                var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (int.TryParse(userIdClaim, out int userId))
                {
                    var projectDto = new ProjectDto
                    {
                        Name = projectViewModel.Name,
                        Description = projectViewModel.Description,
                        UserId = userId
                    };

                    await _projectAppService.AddProjectAsync(projectDto);
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError(string.Empty, "Unable to retrieve User ID from claims.");
            }

            return View(projectViewModel);
        }
    }
}
