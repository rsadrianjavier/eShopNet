using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(eShop.Web.Startup))]
namespace eShop.Web
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
