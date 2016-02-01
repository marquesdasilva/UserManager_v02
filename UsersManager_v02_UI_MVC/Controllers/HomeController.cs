using System.Web.Mvc;
using UsersManager_v02_UI_MVC.Models.Widgets;

namespace UsersManager_v02_UI_MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            TempData[AlertMessage.StringAlert] = AlertHelper.GenerateAlert(NotificationType.INFO, "Welcome!");
            return View();
        }
    }
}