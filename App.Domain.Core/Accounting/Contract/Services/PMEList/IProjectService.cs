using App.Domain.Core.Accounting.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Accounting.Contract.Services.PMEList
{
    public interface IProjectService
    {
        Task AddProjectAsync(ProjectDto projectDto);
        Task<List<ProjectDto>> GetProjectsByUserIdAsync(int userId);
    }
}
