using VersionEndpoint.Middleware;
using VersionEndpoint.Middleware.Providers;
using Microsoft.AspNetCore.Builder;
using System.IO.Abstractions;

namespace Microsoft.Extensions.DependencyInjection.VersionEndpoint
{
    public static class VersionEndpointExtensions
    {
        public static void AddVersionEndpoint(this IServiceCollection services)
        {
            services.AddSingleton<IFileSystem, FileSystem>();
            services.AddSingleton<IVersionProvider, JsonFileVersionProvider>();
        }

        public static IApplicationBuilder UseVersionEndpoint(this IApplicationBuilder app, string path)
        {
            return app.Map(path, a => a.UseMiddleware<VersionEndpointMiddleware>());
        }
    }
}
