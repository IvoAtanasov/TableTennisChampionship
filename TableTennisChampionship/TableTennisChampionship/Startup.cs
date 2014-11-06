using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TableTennisChampionship.Startup))]
namespace TableTennisChampionship
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
