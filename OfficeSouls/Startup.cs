using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OfficeSouls.Startup))]
namespace OfficeSouls
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
