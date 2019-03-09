namespace LibraryManager.Test.Hooks
{
    using LibraryManager.Client;
    using System.Diagnostics;
    using System.Net.Http;
    using System.Threading.Tasks;
    using TechTalk.SpecFlow;
    using Utilities;

    [Binding]
    public class BaseHook
    {
        public static HttpRequestHandler httpRequestHandler;
        public static LibraryManagerSettings libraryManagerSettings;
        public static BookClient bookClient;
        public static Task<HttpResponseMessage> result;

        private static Process process;

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            httpRequestHandler = new HttpRequestHandler();
            libraryManagerSettings = new LibraryManagerSettings();
            bookClient = new BookClient();

            process = Process.Start(".\\exe\\LibraryManager.exe");
        }

        [BeforeScenario]
        public static void BeforeScenario()
        {
                    
        }

        [AfterScenario]
        public static void AfterScenario()
        {
         
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            process.Kill();
        }
    }
}