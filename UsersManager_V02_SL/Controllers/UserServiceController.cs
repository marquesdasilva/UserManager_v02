using System.Linq;
using System.Web.Http;
using UsersManager_v02_BL.UsersManager.UnitOfWork;


namespace UsersManager_V02_SL.Controllers
{
    public class UserServiceController : ApiController
    {
        private UnitOfWork UOF= new UnitOfWork();

        // GET: UserService
        public string GetUsersList()
        {
            var Users = UOF.UserRepository.Get().ToList();
            
            //var UsersJson = JsonConvert
            //return UsersJson;
            return "";
        }

        // GET: UserService
        //public string GetProblems()
        //{
        //    var Users = UOF.UserRepository.Get();
        //    //var UsersJson = 
        //    //return UsersJson;
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                UOF.Context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
