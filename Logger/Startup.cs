using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Logger.Startup))]
namespace Logger
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
