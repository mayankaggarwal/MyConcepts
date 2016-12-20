using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TempApp.Startup))]
namespace TempApp
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
