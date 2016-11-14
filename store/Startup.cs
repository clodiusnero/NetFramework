using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(store.Startup))]
namespace store
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
