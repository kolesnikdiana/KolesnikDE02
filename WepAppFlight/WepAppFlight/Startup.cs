using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WepAppFlight.Startup))]
namespace WepAppFlight
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
