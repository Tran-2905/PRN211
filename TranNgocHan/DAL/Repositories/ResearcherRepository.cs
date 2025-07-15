using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ResearcherRepository
    {
        private readonly Su25researchDbContext _context;
        public ResearcherRepository()
        {
            _context = new Su25researchDbContext();
        }
        public List<Researcher> GetAllResearchers()
        {
            return _context.Researchers.ToList();
        }
    }
}