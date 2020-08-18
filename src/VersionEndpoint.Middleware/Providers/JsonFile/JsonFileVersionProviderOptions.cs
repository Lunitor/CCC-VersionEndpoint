namespace VersionEndpoint.Middleware.Providers.JsonFile
{
    internal class JsonFileVersionProviderOptions : VersionProviderOptions
    {
        public string FilePath { get; set; }

        public JsonFileVersionProviderOptions(string filePath)
        {
            ProviderServicesRegisterType = typeof(JsonFileVersionProviderServicesRegister);
            FilePath = filePath;
        }
    }
}
