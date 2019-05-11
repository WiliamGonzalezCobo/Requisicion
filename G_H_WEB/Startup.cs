using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(G_H_WEB.Startup))]
namespace G_H_WEB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
