using System;
using TechTalk.SpecFlow;

namespace LibraryManager.Test.Hooks
{
    public class BaseHook
    {
        [Binding]
            public class BaseHook
            {
                public static HttpRequestHandler httpRequestHandler;
                public static BlockexWebApiSettings blockexWebApiSettings;
                public static AuthService auth;

                public static AuthenticationClient authenticationClient;
                public static TraderClient traderClient;
                public static KycClient kycClient;
                public static CaseAllocatorClient caseAllocatorClient;
                public static BoTraderClient boTraderClient;
                public static CryptoCurrencyWalletClient cryptoCurrencyWalletClient;
                public static DepositsClient depositsClient;

                [BeforeTestRun]
                public static void BeforeTestRun()
                {
                    httpRequestHandler = new HttpRequestHandler();
                    blockexWebApiSettings = new BlockexWebApiSettings();
                    auth = new AuthService();

                    authenticationClient = new AuthenticationClient();
                    kycClient = new KycClient();
                    caseAllocatorClient = new CaseAllocatorClient();
                    traderClient = new TraderClient();
                    boTraderClient = new BoTraderClient();
                    cryptoCurrencyWalletClient = new CryptoCurrencyWalletClient();
                    depositsClient = new DepositsClient();
                }

                [BeforeScenario]
                public static void BeforeScenario()
                {
                    //TODO: Implement logic that has to run before executing each scenario
                }

                [AfterScenario]
                public static void AfterScenario()
                {
                    //TODO: Implement logic that has to run after executing each scenario
                }

                [AfterTestRun]
                public static void AfterTestRun()
                {
                    //TODO: Implement logic that has to run after test run
                }
            }
    }
}
