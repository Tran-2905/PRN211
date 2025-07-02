using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class ResearcherService
    {
        private readonly DAL.Repository.ResearcherRepository _repository;
        public ResearcherService()
        {
            _repository = new DAL.Repository.ResearcherRepository();
        }
        public List<DAL.Entity.Researcher> GetAllResearchers()
        {
            return _repository.GetAllResearchers();
        }
    }
}
