using Microsoft.EntityFrameworkCore;
using ResearchProjectManagement_SE180242_DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResearchProjectManagement_SE180242_DAL.Repositories
{
    public class UserAccountRepository
    {
        private readonly Su25researchDbContext _context;
        public UserAccountRepository()
        {
            _context = new Su25researchDbContext();
        }
        public UserAccount GetByUserNamePassWord(string email, string password)
        {
            var user = _context.UserAccounts
                .FirstOrDefault(u => u.Email == email && u.Password == password);
            return user;
        }
    }
}
