using DAL.Entities;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ResearchProjectService
    {
        private readonly ResearchProjectRepository _repository;
        public ResearchProjectService()
        {
            _repository = new ResearchProjectRepository();
        }
        public List<ResearchProject> GetAllProjects()
        {
            return _repository.getALL();
        }
        public ResearchProject GetProjectById(int projectId)
        {
            return _repository.getALL().FirstOrDefault(p => p.ProjectId == projectId);
        }

        public List<ResearchProject> GetProjectByTitleOrField(string text)
        {
            return _repository.getALL()
                 .Where(p => p.ProjectTitle.Contains(text, StringComparison.OrdinalIgnoreCase) ||
                             p.ResearchField.Contains(text, StringComparison.OrdinalIgnoreCase))
                 .ToList();
        }

        public void AddProject(ResearchProject project)
        {
            _repository.AddProject(project);
        }
        public void UpdateProject(ResearchProject project)
        {
            _repository.UpdateProject(project);
        }
        public void DeleteProject(int projectId)
        {
            _repository.DeleteProject(projectId);
        }
    }
}
