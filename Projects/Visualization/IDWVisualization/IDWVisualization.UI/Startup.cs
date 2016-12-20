using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IDWVisualization.UI.Startup))]
namespace IDWVisualization.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
