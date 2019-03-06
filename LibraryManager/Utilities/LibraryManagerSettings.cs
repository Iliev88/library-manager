namespace Utilities
{
    using System.Configuration;

    public class LibraryManagerSettings
    {
        public string BaseUrl { get; set; }

        public LibraryManagerSettings()
        {
            BaseUrl = ConfigurationManager.AppSettings["baseUrl"];
        }
    }
}
