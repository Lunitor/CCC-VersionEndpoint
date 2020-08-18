using Microsoft.Extensions.DependencyInjection;

namespace VersionEndpoint.Middleware.Providers
{
    internal interface IVersionProviderServicesRegister
    {
        void RegisterRequiredServices(IServiceCollection services, VersionProviderOptions options);
    }
}
