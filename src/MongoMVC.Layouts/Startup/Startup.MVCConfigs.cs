using Microsoft.Framework.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using Newtonsoft.Json.Serialization;

namespace MongoMVC.Layouts
{
    public partial class Startup
    {
        private static void ConfigurationMVC(IServiceCollection services)
        {
            services.ConfigureMvc(MVCOptionsConfigs);
            services.AddMvc();
        }
        private static void MVCOptionsConfigs(MvcOptions opts)
        {
            opts.OutputFormatters.Clear();
            JsonSerializerSettings jsonSettings = new JsonSerializerSettings();
            jsonSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            opts.OutputFormatters.Add(new JsonOutputFormatter(jsonSettings));

        }
      
    }
}
