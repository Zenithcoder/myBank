using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(myBank.Startup))]
namespace myBank
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
