namespace VersionEndpoint.Middleware
{
    internal class Version
    {
        public string BuildId { get; set; }
        public string BuildBranch { get; set; }
        public string BuildCommit { get; set; }

        public string ReleaseId { get; set; }
    }
}
