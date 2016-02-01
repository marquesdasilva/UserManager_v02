using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UsersManager_v02_BL.DesignPatternHelpers;
using UsersManager_v02_DAL.DbConnection;
using UsersManager_v02_DAL.Entities;

namespace UsersManager_v02_BL.UsersManager.Repositories
{
    public class UserRepository : GenericRepository<User>
    {
        public UserRepository(DatabaseContext Ctx) : base(Ctx)
        {
        }

        /// <summary>
        /// Function that returns a list of users according to the search parameter, number of records and current subset
        /// </summary>
        /// <param name="sortOrder">E.g: Name, Name_desc, Username, Username_desc, Email, Email_desc</param>
        /// <param name="searchString">E.g: Search string to search by: name, username or email address</param>
        /// <param name="pageSize">E.g: Number of records to take</param>
        /// <param name="page">E.g: Current Page</param>
        /// <returns></returns>
        public IEnumerable<User> GetUsers(string sortOrder, string searchString,int pageSize=10, int page = 1)
        {
            var users = this.Get();

            if (!String.IsNullOrEmpty(searchString))
            {
                users = users.Where(s => s.Name.Contains(searchString)
                                            || s.Username.Contains(searchString)
                                            || s.EmailAdress.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "Name_desc":
                    users = users.OrderByDescending(s => s.Name);
                    break;
                case "Username":
                    users = users.OrderBy(s => s.Username);
                    break;
                case "Username_desc":
                    users = users.OrderByDescending(s => s.Username);
                    break;
                case "Email":
                    users = users.OrderBy(s => s.EmailAdress);
                    break;
                case "Email_desc":
                    users = users.OrderByDescending(s => s.EmailAdress);
                    break;
                default:
                    users = users.OrderBy(s => s.Name);
                    break;
            }

            users = users.Skip(pageSize * (page-1)).Take(pageSize);

            return users;
        }

    }
}
