using LibraryManager.Test.Hooks;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using TechTalk.SpecFlow;

namespace LibraryManager.Test.Definitions
{
    [Binding]
    public sealed class GetBookStepDefinition
    {
        [StepDefinition(@"book is requested (.*)")]
        public void GivenBookIsRequested(int id)
        {
            BaseHook.result = BaseHook.bookClient.GetBook(id);
        }

        [Then(@"book should not be retrieved (.*)")]
        public void ThenBookShouldNotBeRetrieved(string error)
        {
            var errorMessage = BaseHook.httpRequestHandler.GetHttpRequestMsgAsString(BaseHook.result);

            Assert.That(errorMessage, Does.Contain(error));
            Console.WriteLine(errorMessage);
        }

        [Then(@"not found status code should be returned")]
        public void ThenNotFoundStatusCodeShouldBeReturned()
        {
            Assert.AreEqual(HttpStatusCode.NotFound, BaseHook.result.Result.StatusCode);
        }


    }
}
