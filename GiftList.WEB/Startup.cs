using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GiftList.WEB.Startup))]
namespace GiftList.WEB
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
