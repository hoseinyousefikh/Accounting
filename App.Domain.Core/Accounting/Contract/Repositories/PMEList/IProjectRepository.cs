using App.Domain.Core.Accounting.Entities.PMEList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Accounting.Contract.Repositories.PMEList
{
    public interface IProjectRepository
    {
        Task AddProject(Project project);
        Task UpdateProject(Project project);
        Task DeleteProject(int id);
        Task<Project> GetProjectById(int id);
        Task<List<Project>> GetProjectByUserId(int userId);
    }
}
