using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(amis.Startup))]
namespace amis
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
