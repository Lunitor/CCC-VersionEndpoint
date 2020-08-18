using Microsoft.AspNetCore.Builder;
using System;
using VersionEndpoint.Middleware;
using VersionEndpoint.Middleware.Providers;

namespace Microsoft.Extensions.DependencyInjection.VersionEndpoint
{
    public static class VersionEndpointExtensions
    {
        public static void AddVersionEndpoint(this IServiceCollection services, Action<VersionProviderOptionsBuilder> optionsAction)
        {
            var optionsBuilder = new VersionProviderOptionsBuilder();
            optionsAction.Invoke(optionsBuilder);

            var options = optionsBuilder.Options;

            var providerServicesRegister = Activator.CreateInstance(options.ProviderServicesRegisterType) as IVersionProviderServicesRegister;
            providerServicesRegister.RegisterRequiredServices(services, options);
        }

        public static IApplicationBuilder UseVersionEndpoint(this IApplicationBuilder app, string path)
        {
            return app.Map(path, a => a.UseMiddleware<VersionEndpointMiddleware>());
        }
    }
}
