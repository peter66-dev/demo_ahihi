using MyLib.DataAccess;
using MyLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib.Repository
{
    public class UserRepository : IUserRepository
    {
        public AccountUser CheckLogin(string id, string psw)
            => UserDAO.Instance.CheckLogin(id, psw);

        public async Task<IEnumerable<AccountUser>> GetAllUsersAsync()
            => await UserDAO.Instance.GetAllUsersAsync();
        public async Task<IEnumerable<AccountUser>> Search(string msg)
            => await UserDAO.Instance.Search(msg);
        public AccountUser GetUserById(string id)
            => UserDAO.Instance.GetUserById(id);
        public bool CheckNameDuplicated(string id, string name)
            => UserDAO.Instance.CheckNameDuplicated(id, name);
        public bool UpdateUser(AccountUser user)
            => UserDAO.Instance.UpdateUser(user);
        public bool DeleteUser(string id)
            => UserDAO.Instance.DeleteUser(id);
        public bool CreateUser(AccountUser user)
            => UserDAO.Instance.CreateUser(user);
    }
}
