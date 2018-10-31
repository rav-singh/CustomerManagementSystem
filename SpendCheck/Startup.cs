using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CustomerManagementSys.Startup))]
namespace CustomerManagementSys
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
