using LibraryManager.Test.Hooks;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace LibraryManager.Test.Definitions.Then
{
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
