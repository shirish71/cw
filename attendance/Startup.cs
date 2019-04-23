using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(attendance.Startup))]
namespace attendance
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
