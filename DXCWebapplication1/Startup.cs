using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DXCWebapplication1.Startup))]
namespace DXCWebapplication1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
