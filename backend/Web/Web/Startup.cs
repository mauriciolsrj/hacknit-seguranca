using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GuardaDigital.Startup))]
namespace GuardaDigital
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
