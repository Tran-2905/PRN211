using ResearchProjectManagement_SE180242_DAL.Entity;
using ResearchProjectManagement_SE180242_DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResearchProjectManagement_BLL.Service
{
    public class UserAccountService
    {
        private readonly UserAccountRepository userAccountRepository;
        public UserAccountService()
        {
            userAccountRepository = new UserAccountRepository();
        }
        public UserAccount ValidateCredentials(string email, string password)
        {
            return userAccountRepository.GetByUserNamePassWord(email, password);
        }
    }
}
