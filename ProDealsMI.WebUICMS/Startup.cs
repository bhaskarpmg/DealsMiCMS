using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProDealsMI.WebUICMS.Startup))]
namespace ProDealsMI.WebUICMS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
