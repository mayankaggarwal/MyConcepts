using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC4._5App.Startup))]
namespace MVC4._5App
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
