namespace LibraryManager.Test.Definitions.Then
{
    using LibraryManager.Test.Hooks;
    using NUnit.Framework;
    using System;
    using TechTalk.SpecFlow;

    [Binding]
    public sealed class ErrorMessageStepDefinition
    {
        [Then(@"error message (.*)")]
        public void ThenErrorMessage(string error)
        {
            var errorMessage = BaseHook.httpRequestHandler.GetHttpRequestMsgAsString(BaseHook.result);

            Assert.That(errorMessage, Does.Contain(error));
            Console.WriteLine(errorMessage);
        }
    }
}
