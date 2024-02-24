using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JobLinking.Startup))]
namespace JobLinking
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
