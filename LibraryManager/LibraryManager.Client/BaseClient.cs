using Utilities;

namespace LibraryManager.Client
{
    public class BaseClient
    {
        protected HttpRequestHandler httpRequestHandler;
        public LibraryManagerSettings libraryManagerSettings;

        public BaseClient()
        {
            httpRequestHandler = new HttpRequestHandler();
            libraryManagerSettings = new LibraryManagerSettings();
        }
    }
}
