using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCwithMySql.Startup))]
namespace MVCwithMySql
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
