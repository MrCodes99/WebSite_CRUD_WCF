using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebSite_Semana11_Lunes.Startup))]
namespace WebSite_Semana11_Lunes
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
