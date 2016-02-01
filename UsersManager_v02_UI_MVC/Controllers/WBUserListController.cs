using PagedList;
using System;
using System.Linq;
using System.Web.Mvc;
using UsersManager_v02_BL.UsersManager.UnitOfWork;
using UsersManager_v02_DAL.Entities;

namespace UserListManager_v02_UI_MVC.Controllers
{
    public class WBUserListController : Controller
    {
        private UnitOfWork UOW = new UnitOfWork();
        private IQueryable<User> UserList;

        public ActionResult Preparation(int DepartmentId = 1)
        {
            UserList = UOW.UserRepository.Get();

            return GetListUsers(null, null, null);
        }
        
        // GET: GetListUserList
        public PartialViewResult GetListUsers(string SortOrder, string CurrentFilter, string SearchString, int? Page = 1)
        {
            int pageSize = 10;

            ViewBag.CurrentSort = SortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(SortOrder) ? "Name_desc" : "";
            ViewBag.UsernameSortParm = SortOrder == "Username" ? "Username_desc" : "Username";
            ViewBag.EmailSortParm = SortOrder == "Email" ? "Email_desc" : "Email";

            if (SearchString != null)
            {
                Page = 1;
            }
            else
            {
                SearchString = CurrentFilter;
            }

            ViewBag.CurrentFilter = SearchString;

            UserList = UOW.UserRepository.Get();

            if (!String.IsNullOrEmpty(SearchString))
            {
                UserList = UserList.Where(s => s.Name.Contains(SearchString)
                                           || s.Username.Contains(SearchString)
                                           || s.EmailAdress.Contains(SearchString));
            }

            ViewBag.Count = UserList.Count();

            switch (SortOrder)
            {
                case "Name_desc":
                    UserList = UserList.OrderByDescending(s => s.Name);
                    break;
                case "Username":
                    UserList = UserList.OrderBy(s => s.Username);
                    break;
                case "Username_desc":
                    UserList = UserList.OrderByDescending(s => s.Username);
                    break;
                case "Email":
                    UserList = UserList.OrderBy(s => s.EmailAdress);
                    break;
                case "Email_desc":
                    UserList = UserList.OrderByDescending(s => s.EmailAdress);
                    break;
                default:
                    UserList = UserList.OrderBy(s => s.Name);
                    break;
            }

            int pageNumber = (Page ?? 1);

            return PartialView("GetListUsers",UserList.ToList().ToPagedList(pageNumber, pageSize));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                UOW.Context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
