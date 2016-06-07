using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StreamyTVMVC.Startup))]
namespace StreamyTVMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
