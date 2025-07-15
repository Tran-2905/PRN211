using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ResearchProjectRepository
    {
        private readonly Su25researchDbContext _context;
        public ResearchProjectRepository()
        {
            _context = new Su25researchDbContext();
        }

        public List<ResearchProject> getALL()
        {
            return _context.ResearchProjects.Include(rp => rp.LeadResearcher).ToList();
        }
        public void DeleteProject(int projectId)
        {
            var project = _context.ResearchProjects.Find(projectId);
            if (project != null)
            {
                _context.ResearchProjects.Remove(project);
                _context.SaveChanges();
            }
        }
        public void AddProject(ResearchProject project)
        {
            project.ProjectId = _context.ResearchProjects.Max(p => p.ProjectId) + 1;
            _context.ResearchProjects.Add(project);
            _context.SaveChanges();
        }
        public void UpdateProject(ResearchProject project)
        {
            var existingProject = _context.ResearchProjects.Find(project.ProjectId);
            if (existingProject != null)
            {
                existingProject.ProjectTitle = project.ProjectTitle;
                existingProject.ResearchField = project.ResearchField;
                existingProject.StartDate = project.StartDate;
                existingProject.EndDate = project.EndDate;
                Console.WriteLine(project.LeadResearcherId);
                existingProject.LeadResearcherId = project.LeadResearcherId;
                existingProject.Budget = project.Budget;
                _context.ResearchProjects.Update(existingProject);
                _context.SaveChanges();
            }

        }
    }
}
