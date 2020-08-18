using Ardalis.GuardClauses;
using System.IO.Abstractions;
using System.Text.Json;

namespace VersionEndpoint.Middleware.Providers
{
    internal class JsonFileVersionProvider : IVersionProvider
    {
        private readonly IFileSystem _fileSystem;

        public JsonFileVersionProvider(IFileSystem fileSystem)
        {
            Guard.Against.Null(fileSystem, nameof(fileSystem));

            _fileSystem = fileSystem;
        }

        public Version GetVersion()
        {
            var json = _fileSystem.File.ReadAllText("version.json");

            var buildReleaseInfo = JsonSerializer.Deserialize<Version>(json);

            return buildReleaseInfo;
        }
    }
}
