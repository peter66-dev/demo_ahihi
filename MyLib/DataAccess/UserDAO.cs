using Microsoft.EntityFrameworkCore;
using MyLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib.DataAccess
{
    public class UserDAO
    {
        private static UserDAO instance = null;
        private static readonly object instanceLock = new object();
        private UserDAO() { }

        public static UserDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new UserDAO();
                    }
                }
                return instance;
            }
        }

        public AccountUser CheckLogin(string id, string psw)
        {
            AccountUser user = null;
            try
            {
                var context = new BookPublisherContext();
                user = context.AccountUsers.FirstOrDefault(u => u.UserId.Equals(id) && u.UserPassword.Equals(psw));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error at CheckLogin: " + ex.Message);
            }

            return user;
        }

        public AccountUser GetUserById(string id)
        {
            AccountUser user = null;
            try
            {
                var context = new BookPublisherContext();
                user = context.AccountUsers.FirstOrDefault(u => u.UserId.Equals(id));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error at GetUserById: " + ex.Message);
            }

            return user;
        }

        public bool CheckNameDuplicated(string id, string name)
        {
            bool check = false;
            try
            {
                var context = new BookPublisherContext();
                AccountUser u = context.AccountUsers.FirstOrDefault(u => !u.UserId.Equals(id) && u.UserFullName.Equals(name));
                check = u != null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error at CheckNameDuplicated: " + ex.Message);
            }

            return check;
        }

        public bool CreateUser(AccountUser user)
        {
            bool check = false;
            try
            {
                var context = new BookPublisherContext();
                context.AccountUsers.Add(user);
                check = context.SaveChanges() > 0;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error at CreateUser: " + ex.Message);
            }

            return check;
        }

        public bool UpdateUser(AccountUser user)
        {
            bool check = false;
            try
            {
                var context = new BookPublisherContext();
                AccountUser u = context.AccountUsers.FirstOrDefault(u => u.UserId.Equals(user.UserId));
                u.UserPassword = user.UserPassword;
                u.UserFullName = user.UserFullName;
                u.UserRole = user.UserRole;
                context.Entry(u).State = EntityState.Modified;
                check = context.SaveChanges() > 0;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error at UpdateUser: " + ex.Message);
            }

            return check;
        }

        public bool DeleteUser(string id)
        {
            bool check = false;
            try
            {
                var context = new BookPublisherContext();
                AccountUser u = context.AccountUsers.FirstOrDefault(u => u.UserId.Equals(id));
                context.AccountUsers.Remove(u);
                check = context.SaveChanges() > 0;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error at DeleteUser: " + ex.Message);
            }

            return check;
        }

        public async Task<IEnumerable<AccountUser>> GetAllUsersAsync()
        {
            IEnumerable<AccountUser> list = new List<AccountUser>();
            try
            {
                var context = new BookPublisherContext();
                list = await context.AccountUsers.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error at GetAllUsersAsync: " + ex.Message);
            }

            return list;
        }

        public async Task<IEnumerable<AccountUser>> Search(string msg)
        {
            IEnumerable<AccountUser> list = new List<AccountUser>();
            try
            {
                var context = new BookPublisherContext();
                list = await context.AccountUsers.Where(u => u.UserFullName.Contains(msg.Trim())).ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error at Search: " + ex.Message);
            }

            return list;
        }
    }
}
