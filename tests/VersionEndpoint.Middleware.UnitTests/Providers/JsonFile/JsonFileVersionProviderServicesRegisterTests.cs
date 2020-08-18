using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using VersionEndpoint.Middleware.Providers;
using VersionEndpoint.Middleware.Providers.JsonFile;
using Xunit;

namespace VersionEndpoint.Middleware.UnitTests.Providers.JsonFile
{
    public class JsonFileVersionProviderServicesRegisterTests
    {
        private readonly JsonFileVersionProviderServicesRegister _servicesRegister;

        private readonly Mock<IServiceCollection> _serviceCollectionMock;

        private readonly JsonFileVersionProviderOptions _jsonFileVersionProviderOptions = new JsonFileVersionProviderOptions("test.json");

        public JsonFileVersionProviderServicesRegisterTests()
        {
            _serviceCollectionMock = new Mock<IServiceCollection>();

            _servicesRegister = new JsonFileVersionProviderServicesRegister();
        }

        [Fact]
        public void RegisterRequiredServicesShouldThrowArgumentNullExceptionWhenServiceCollectionIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => _servicesRegister.RegisterRequiredServices(null, _jsonFileVersionProviderOptions));
        }

        [Fact]
        public void RegisterRequiredServicesShouldThrowArgumentNullExceptionWhenVersionProviderOptionsIsNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
                _servicesRegister.RegisterRequiredServices(_serviceCollectionMock.Object, null));
        }

        [Fact]
        public void RegisterRequiredServicesShouldThrowArgumentExceptionWhenOptionsTypeIsNotJsonFileVersionProviderOptions()
        {
            Assert.Throws<ArgumentException>(() =>
                _servicesRegister.RegisterRequiredServices(_serviceCollectionMock.Object, new TestVersionProviderOptions()));
        }

        public class TestVersionProviderOptions : VersionProviderOptions
        { }
    }
}
