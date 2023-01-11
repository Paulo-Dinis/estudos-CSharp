using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TISelvagem.UI.web.Startup))]
namespace TISelvagem.UI.web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
