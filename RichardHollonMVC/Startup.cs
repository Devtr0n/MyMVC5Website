using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RichardHollonMVC.Startup))]
namespace RichardHollonMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
