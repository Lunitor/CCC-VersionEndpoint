using Ardalis.GuardClauses;
using System.IO.Abstractions;
using System.Text.Json;

namespace VersionEndpoint.Middleware.Providers.JsonFile
{
    internal class JsonFileVersionProvider : IVersionProvider
    {
        private readonly IFileSystem _fileSystem;
        private readonly string _filePath;

        public JsonFileVersionProvider(IFileSystem fileSystem, string filePath)
        {
            Guard.Against.Null(fileSystem, nameof(fileSystem));
            Guard.Against.NullOrEmpty(filePath, nameof(filePath));

            _fileSystem = fileSystem;
            _filePath = filePath;
        }

        public Version GetVersion()
        {
            var json = _fileSystem.File.ReadAllText(_filePath);

            var buildReleaseInfo = JsonSerializer.Deserialize<Version>(json);

            return buildReleaseInfo;
        }
    }
}
