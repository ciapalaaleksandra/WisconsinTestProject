using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WisconsinTest.Startup))]
namespace WisconsinTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
