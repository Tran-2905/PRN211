using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entity;
using DAL.Repository;

namespace BLL.Service
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
