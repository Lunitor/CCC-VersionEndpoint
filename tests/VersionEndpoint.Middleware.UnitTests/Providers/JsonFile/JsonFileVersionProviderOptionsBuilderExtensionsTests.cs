using VersionEndpoint.Middleware.Providers;
using VersionEndpoint.Middleware.Providers.JsonFile;
using Xunit;

namespace VersionEndpoint.Middleware.UnitTests.Providers.JsonFile
{
    public class JsonFileVersionProviderOptionsBuilderExtensionsTests
    {
        private readonly VersionProviderOptionsBuilder _optionsBuilder;

        public JsonFileVersionProviderOptionsBuilderExtensionsTests()
        {
            _optionsBuilder = new VersionProviderOptionsBuilder();
        }

        [Fact]
        public void UseJsonFileVersionProviderShouldAddJsonFileVersionProviderOptionsToOptionsBuilder()
        {
            _optionsBuilder.UseJsonFileVersionProvider("test.json");

            var options = _optionsBuilder.Options;

            Assert.IsType<JsonFileVersionProviderOptions>(options);
        }

        [Fact]
        public void UseJsonFileVersionProviderShouldAddJsonFileVersionProviderOptionsWithThePAssedFilePAthToOptionsBuilder()
        {
            var testFilePath = "test.json";

            _optionsBuilder.UseJsonFileVersionProvider(testFilePath);

            var options = _optionsBuilder.Options as JsonFileVersionProviderOptions;

            Assert.Equal(testFilePath, options.FilePath);
        }
    }
}
