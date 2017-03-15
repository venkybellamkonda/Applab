using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Applabs.demo.marketing.Startup))]
namespace Applabs.demo.marketing
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
