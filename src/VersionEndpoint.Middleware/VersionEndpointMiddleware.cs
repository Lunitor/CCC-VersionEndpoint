using VersionEndpoint.Middleware.Providers;
using Microsoft.AspNetCore.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace VersionEndpoint.Middleware
{
    internal class VersionEndpointMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IVersionProvider _versionProvider;

        public VersionEndpointMiddleware(RequestDelegate next, IVersionProvider versionProvider)
        {
            _next = next;
            _versionProvider = versionProvider;
        }

        public Task Invoke(HttpContext httpContext)
        {
            var version = _versionProvider.GetVersion();

            var versionJson = JsonSerializer.Serialize(version);

            httpContext.Response.ContentType = "application/json";
            return httpContext.Response.WriteAsync(versionJson);
        }
    }
}
