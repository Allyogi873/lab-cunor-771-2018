using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(waPruebaLogin.Startup))]
namespace waPruebaLogin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
