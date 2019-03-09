using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using LibraryManager.Client;
using TechTalk.SpecFlow;
using Utilities;

namespace LibraryManager.Test.Hooks
{
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