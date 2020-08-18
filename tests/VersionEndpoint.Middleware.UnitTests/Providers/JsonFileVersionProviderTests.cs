using VersionEndpoint.Middleware.Providers;
using Moq;
using System;
using System.IO.Abstractions;
using Xunit;

namespace VersionEndpoint.Middleware.UnitTests.Providers
{
    public class JsonFileVersionProviderTests
    {
        private readonly JsonFileVersionProvider _jsonFileVersionProvider;

        private readonly Mock<IFileSystem> _fileSystemMock;

        private readonly Version TestVersion = new Version
        {
            BuildId = "20200814.2",
            BuildBranch = "master",
            BuildCommit = "bbdc960",
            ReleaseId = "Release-17"
        };

        private readonly string TestVersionSerialized = @"{
          ""BuildId"": ""20200814.2"",
          ""BuildBranch"": ""master"",
          ""BuildCommit"": ""bbdc960"",
          ""ReleaseId"": ""Release-17""
        }";

        public JsonFileVersionProviderTests()
        {
            _fileSystemMock = new Mock<IFileSystem>();

            _jsonFileVersionProvider = new JsonFileVersionProvider(_fileSystemMock.Object);
        }

        [Fact]
        public void ConstructorShouldThrowArgumentNullExceptionWhenNullFileSystemPassed()
        {
            Assert.Throws<ArgumentNullException>(() => new JsonFileVersionProvider(null));
        }

        [Fact]
        public void GetVersionShouldReturnTheDeserializedJson()
        {
            _fileSystemMock.Setup(fs => fs.File.ReadAllText(It.IsAny<string>()))
                .Returns(TestVersionSerialized);

            var version = _jsonFileVersionProvider.GetVersion();

            Assert.NotNull(version);
            Assert.Equal(TestVersion.BuildId, version.BuildId);
            Assert.Equal(TestVersion.BuildBranch, version.BuildBranch);
            Assert.Equal(TestVersion.BuildCommit, version.BuildCommit);
            Assert.Equal(TestVersion.ReleaseId, version.ReleaseId);
        }
    }
}
