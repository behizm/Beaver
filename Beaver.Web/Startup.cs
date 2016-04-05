using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Beaver.Web.Startup))]
namespace Beaver.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
