using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NinjaLaptops.WebClient.Startup))]
namespace NinjaLaptops.WebClient
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
