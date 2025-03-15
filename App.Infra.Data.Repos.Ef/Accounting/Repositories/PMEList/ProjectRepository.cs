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
    public class ProjectRepository : IProjectRepository
    {
        private readonly AppDbContext _context;

        public ProjectRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddProject(Project project)
        {
            await _context.Projects.AddAsync(project);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProject(Project project)
        {
            _context.Projects.Update(project);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProject(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project != null)
            {
                project.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Project> GetProjectById(int id)
        {
            var x = await _context.Projects
                .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);
            if (x != null)
            {
                return x;
            }
            throw new Exception("is null");
        }

        public async Task<List<Project>> GetProjectByUserId(int userId)
        {
            return await _context.Projects
                .Where(p => p.UserId == userId && !p.IsDeleted)
                .ToListAsync();
        }
    }
}
