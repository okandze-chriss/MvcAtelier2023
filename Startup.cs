using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcGLAtelelier2023.Startup))]
namespace MvcGLAtelelier2023
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
