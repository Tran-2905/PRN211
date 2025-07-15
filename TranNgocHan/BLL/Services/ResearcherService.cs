using DAL.Entities;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ResearcherService
    {
        private ResearcherRepository _repository = new();
        public List<Researcher> getAllResearcher()
        {
            return _repository.GetAllResearchers();
        }
    }
}
