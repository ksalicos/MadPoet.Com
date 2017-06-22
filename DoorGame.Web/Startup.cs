using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DoorGame.Web.Startup))]
namespace DoorGame.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
