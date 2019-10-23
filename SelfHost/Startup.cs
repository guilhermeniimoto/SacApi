using Owin;

namespace SacHost
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseErrorPage();
            app.UseWelcomePage("/");
        }
    }
}
