using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC5Exercise1.Startup))]
namespace MVC5Exercise1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
