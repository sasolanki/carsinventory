using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CarsInventory.Web.Startup))]
namespace CarsInventory.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
