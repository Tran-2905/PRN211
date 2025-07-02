using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entity;

namespace BLL.Service
{
    public class ResearchProjectService
    {
        private readonly DAL.Repository.ResearchProjectRepository _repository;
        public ResearchProjectService()
        {
            _repository = new DAL.Repository.ResearchProjectRepository();
        }
        public List<DAL.Entity.ResearchProject> GetAllProjects()
        {
            return _repository.getALL();
        }
        public DAL.Entity.ResearchProject GetProjectById(int projectId)
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

        // Additional methods for adding, updating, and deleting projects can be added here
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
