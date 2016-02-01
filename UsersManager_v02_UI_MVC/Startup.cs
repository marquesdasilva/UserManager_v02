using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UsersManager_v02_UI_MVC.Startup))]
namespace UsersManager_v02_UI_MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
