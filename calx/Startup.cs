using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(calx.Startup))]
namespace calx
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
