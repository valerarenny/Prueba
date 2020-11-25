using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PruebaETechWeb.Startup))]
namespace PruebaETechWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
