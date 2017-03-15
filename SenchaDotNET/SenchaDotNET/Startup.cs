using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SenchaDotNET.Startup))]
namespace SenchaDotNET
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
