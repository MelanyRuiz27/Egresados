using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EgresadosU.Startup))]
namespace EgresadosU
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
