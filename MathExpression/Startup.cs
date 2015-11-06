using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MathExpression.Startup))]
namespace MathExpression
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
