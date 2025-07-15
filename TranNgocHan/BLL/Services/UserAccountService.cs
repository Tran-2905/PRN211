using DAL.Entities;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
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
