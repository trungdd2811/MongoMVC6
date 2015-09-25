using Microsoft.Framework.Configuration;
using Microsoft.Framework.DependencyInjection;
using MongoMVC.Cores.Configurations;

namespace MongoMVC.Layouts
{
    public partial class Startup
    {
        private static void ConfigureOptionsServices(IServiceCollection services, IConfiguration configuration)
        {            
            services.Configure<MongoDBConfigs>(configuration.GetConfigurationSection(nameof(MongoDBConfigs)));

        }
    }
}
