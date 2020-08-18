using System;

namespace VersionEndpoint.Middleware.Providers
{
    public abstract class VersionProviderOptions
    {
        public Type ProviderServicesRegisterType { get; set; }
    }
}
