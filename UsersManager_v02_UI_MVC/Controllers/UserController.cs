using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using UsersManager_v02_BL.UsersManager.UnitOfWork;
using UsersManager_v02_DAL.Entities;
using UsersManager_v02_UI_MVC.Models.Widgets;
using UsersManager_v02_UI_MVC.Models.ViewModels;
using UserManager_v02_IL.Miscellaneous;

namespace UsersManager_v02_UI_MVC.Controllers
{
    public class UserController : Controller
    {
        private UnitOfWork UOW = new UnitOfWork();

        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        // GET: User/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = UOW.UserRepository.GetByID(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            VMUserCreate model = new VMUserCreate();

            return View(model);
        }

        // POST: User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Bind(Include = "User.Name,User.Username,User.Password,ConfirmPassword,User.EmailAdress,User.IsActive")]
        public ActionResult Create(VMUserCreate model)
        {
            if (model.User.Password != model.ConfirmPassword)
            {
                ModelState.AddModelError("User.Password", "The passwords don't match");
                ModelState.AddModelError("ConfirmPassword", "The password don't match");

                model.ConfirmPassword = model.User.Password = String.Empty;
            }
            if(UOW.UserRepository.Get(c => c.Name == model.User.Name).ToList().Count() > 0)
            {
                TempData["Alert"] = AlertHelper.GenerateAlert(Models.Widgets.NotificationType.ERROR, "Already exists one user with this name.");
                return View(model);
            }
            if (UOW.UserRepository.Get(c => c.Username == model.User.Username).ToList().Count() > 0)
            {
                TempData["Alert"] = AlertHelper.GenerateAlert(Models.Widgets.NotificationType.ERROR, "Already exists one user with this username.");
                return View(model);
            }
            if (UOW.UserRepository.Get(c => c.EmailAdress == model.User.EmailAdress).ToList().Count() > 0)
            {
                TempData["Alert"] = AlertHelper.GenerateAlert(Models.Widgets.NotificationType.ERROR, "Already exists one user with this email address.");
                return View(model);
            }

            if (ModelState.IsValid)
            {
                model.User.Password = BCrypt.HashPassword(model.User.Password, BCrypt.GenerateSalt());
                model.User.CreatedBy = UOW.UserRepository.Get().First().Id;
                model.User.CreatedAt = DateTime.Now;

                UOW.UserRepository.Insert(model.User);
                UOW.Save();

                TempData["Alert"] = AlertHelper.GenerateAlert(Models.Widgets.NotificationType.SUCCESS, "User inserted successfully.");

                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: User/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = UOW.UserRepository.GetByID(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Bind(Include = "Id,Name,Username,Password,EmailAdress,IsActive")]
        public ActionResult Edit(User User)
        {
            if (ModelState.IsValid)
            {
                //var loremIpsum = "";

                //if (UOW.UserRepository.Get().Where(p => p.Id == 58).ToList().First().IsActive == true)
                //{
                //    loremIpsum = "";
                //}

                ////isto ta a dar

                if (UOW.UserRepository.Get(c => c.Name == User.Name && c.Id != User.Id).ToList().Count() > 0)
                {
                    TempData["Alert"] = AlertHelper.GenerateAlert(Models.Widgets.NotificationType.ERROR, "Already exists one user with this name.");
                    return View(User);
                }
                if (UOW.UserRepository.Get(c => c.Username == User.Username && c.Id != User.Id).ToList().Count() > 0)
                {
                    TempData["Alert"] = AlertHelper.GenerateAlert(Models.Widgets.NotificationType.ERROR, "Already exists one user with this username.");
                    return View(User);
                }
                if (UOW.UserRepository.Get(c => c.EmailAdress == User.EmailAdress && c.Id != User.Id).ToList().Count() > 0)
                {
                    TempData["Alert"] = AlertHelper.GenerateAlert(Models.Widgets.NotificationType.ERROR, "Already exists one user with this email address.");
                    return View(User);
                }

                var BDUpdated = UOW.UserRepository.GetByID(User.Id);

                User.UpdatedAt = DateTime.Now;
                User.UpdatedBy = 58;

                UOW.Context.Entry(BDUpdated).CurrentValues.SetValues(User);

                UOW.Context.Entry(BDUpdated).State = EntityState.Modified;

               // UOW.UserRepository.Update(BDUpdated);
                UOW.Save();

                TempData["Alert"] = AlertHelper.GenerateAlert(Models.Widgets.NotificationType.SUCCESS, "User updated successfully.");

                //UOW.Save();
                return RedirectToAction("Index");
            }
            return View(User);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                UOW.Context.Dispose();
            }
            base.Dispose(disposing);
        }

        //public ActionResult ListDatatables()
        //{
        //    User User = new User();
        //    return View(User);
        //}
        //public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        //{
        //    var allUsers = UOW.UserRepository.Get();
        //    IEnumerable<User> filteredUsers = allUsers;

        //    var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
        //    Func<User, string> orderingFunction = (c => sortColumnIndex == 0 ? c.Name :
        //                                                        sortColumnIndex == 1 ? c.Username :
        //                                                        c.EmailAdress);

        //    var sortDirection = Request["sSortDir_0"]; // asc or desc
        //    if (sortDirection == "asc")
        //        filteredUsers = filteredUsers.OrderBy(orderingFunction);
        //    else
        //        filteredUsers = filteredUsers.OrderByDescending(orderingFunction);

        //    if (!string.IsNullOrEmpty(param.sSearch))
        //    {
        //        filteredUsers = filteredUsers.Where(c => c.Name.Contains(param.sSearch)
        //                                                || c.Username.Contains(param.sSearch)
        //                                                || c.EmailAdress.Contains(param.sSearch));
        //    }

        //    var displayedUsers = filteredUsers.Skip(param.iDisplayStart).Take(param.iDisplayLength);

        //    var result = from c in displayedUsers
        //                 select new[] { c.Name, c.Username, c.EmailAdress };

        //    var json = Json(new
        //    {
        //        sEcho = param.sEcho,
        //        iTotalRecords = allUsers.Count(),
        //        iTotalDisplayRecords = displayedUsers.Count(),
        //        aaData = result
        //    },
        //        JsonRequestBehavior.AllowGet);

        //    return json;
        //}

        // GET: User
        //public ActionResult List()
        //{
        //    var client = new RestClient("http://localhost:62781/");
        //    var request = new RestRequest("api/UserService/GetUsers", Method.GET);

        //    RestResponse response = client.Execute(request) as RestResponse;

        //    List<RootObject> listUser = new List<RootObject>();
        //    listUser = JsonConvert.DeserializeObject<List<RootObject>>(response.Content);

        //    return View("List", listUser);
        //}

        // GET: User/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    User user = UOW.UserRepository.GetByID(id);
        //    if (user == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(user);
        //}

        //// POST: User/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    User user = UOW.UserRepository.GetByID(id);
        //    UOW.UserRepository.Delete(user);
        //    UOW.Save();
        //    return RedirectToAction("Index");
        //}
    }
}
