using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DeliverySite.Startup))]
namespace DeliverySite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
