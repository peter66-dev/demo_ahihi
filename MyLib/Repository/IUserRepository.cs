using MyLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib.Repository
{
    public interface IUserRepository
    {
        public AccountUser CheckLogin(string id, string psw);
        Task<IEnumerable<AccountUser>> GetAllUsersAsync();
        Task<IEnumerable<AccountUser>> Search(string msg);
        public AccountUser GetUserById(string id);
        public bool CheckNameDuplicated(string id, string name);
        public bool UpdateUser(AccountUser user);
        public bool DeleteUser(string id);
        public bool CreateUser(AccountUser user);
    }
}
