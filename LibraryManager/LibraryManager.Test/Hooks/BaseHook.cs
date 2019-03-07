using System;
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

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            httpRequestHandler = new HttpRequestHandler();
            libraryManagerSettings = new LibraryManagerSettings();
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

        }
    }
}