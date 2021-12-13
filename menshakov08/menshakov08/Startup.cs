using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(menshakov08.Startup))]
namespace menshakov08
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
