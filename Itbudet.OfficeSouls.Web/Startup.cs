using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Itbudet.OfficeSouls.Web.Startup))]
namespace Itbudet.OfficeSouls.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
