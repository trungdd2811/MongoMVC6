using Microsoft.AspNet.Hosting;
using Microsoft.Framework.Configuration;
using Microsoft.Framework.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoMVC.Layouts
{
    public partial class Startup
    {
        private static IConfiguration ConfigureConfiguration(
            IApplicationEnvironment applicationEnvironment,
            IHostingEnvironment hostingEnvironment)
        {
            ConfigurationBuilder configurationBuilder = new ConfigurationBuilder(
                applicationEnvironment.ApplicationBasePath);

            // Add configuration from the config.json file.
            configurationBuilder.AddJsonFile("config.json");
            configurationBuilder.AddJsonFile($"config.{hostingEnvironment.EnvironmentName}.json", optional: true);

          
            configurationBuilder.AddEnvironmentVariables();

            return configurationBuilder.Build();
        }
    }
}
