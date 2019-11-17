using System.Web.Http;
using WebActivatorEx;
using BpeCentral.UI.API;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace BpeCentral.UI.API
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "BpeCentral.UI.API");

                        c.IncludeXmlComments(string.Format(@"{0}\bin\BpeCentral.UI.API.xml", System.AppDomain.CurrentDomain.BaseDirectory));
                    })
                .EnableSwaggerUi(c =>
                    {
                        c.DisableValidator();
                        c.EnableApiKeySupport("Authorization", "header");
                    });
        }
    }
}
