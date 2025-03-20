using App.Domain.Core.Accounting.Contract.AppServices.PMEList;
using App.Domain.Core.Accounting.Contract.Services.PMEList;
using App.Domain.Core.Accounting.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices.Accounting.AppServices.PMEList
{
    public class ProjectAppService : IProjectAppService
    {
        private readonly IProjectService _projectService;
        public ProjectAppService(IProjectService projectService)
        {
            _projectService = projectService;
        }
        public Task AddProjectAsync(ProjectDto projectDto)
        {
            return _projectService.AddProjectAsync(projectDto);
        }

        public Task<List<ProjectDto>> GetProjectsByUserIdAsync(int userId)
        {
            return _projectService.GetProjectsByUserIdAsync(userId);
        }
    }
}
