using Ardalis.GuardClauses;
using VersionEndpoint.Middleware.Providers.JsonFile;

namespace VersionEndpoint.Middleware.Providers
{
    public static class JsonFileVersionProviderOptionsBuilderExtensions
    {
        public static VersionProviderOptionsBuilder UseJsonFileVersionProvider(this VersionProviderOptionsBuilder optionsBuilder, string filePath)
        {
            Guard.Against.Null(filePath, nameof(filePath));

            optionsBuilder.Options = new JsonFileVersionProviderOptions(filePath);

            return optionsBuilder;
        }
    }
}
