using Ardalis.GuardClauses;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO.Abstractions;

namespace VersionEndpoint.Middleware.Providers.JsonFile
{
    internal class JsonFileVersionProviderServicesRegister : IVersionProviderServicesRegister
    {
        public void RegisterRequiredServices(IServiceCollection services, VersionProviderOptions options)
        {
            Guard.Against.Null(services, nameof(services));
            Guard.Against.Null(options, nameof(options));
            if (!(options is JsonFileVersionProviderOptions))
                throw new ArgumentException($"options type is {options.GetType()} but should be {nameof(JsonFileVersionProviderOptions)}");

            var jsonFileOptions = options as JsonFileVersionProviderOptions;

            services.AddSingleton<IFileSystem, FileSystem>();
            services.AddSingleton<IVersionProvider, JsonFileVersionProvider>((services) =>
            {
                var fileSystem = services.GetRequiredService<IFileSystem>();
                return new JsonFileVersionProvider(fileSystem, jsonFileOptions.FilePath);
            });
        }
    }
}
