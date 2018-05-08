using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(kits.Startup))]
namespace kits
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
