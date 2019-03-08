using LibraryManager.Test.Hooks;
using NUnit.Framework;
using System.Net;
using TechTalk.SpecFlow;

namespace LibraryManager.Test.Definitions
{
    [Binding]
    public sealed class DeleteBookStepDefinition
    {
        [When(@"book is deleted (.*)")]
        [Given(@"book is deleted (.*)")]
        public void WhenBookIsDeleted(int id)
        {
            BaseHook.result = BaseHook.bookClient.DeleteBook(id);
        }

        [Then(@"successful status code for deletion should be returned")]
        public void ThenSuccessfulStatusCodeForDeletionShouldBeReturned()
        {
            Assert.AreEqual(HttpStatusCode.NoContent, BaseHook.result.Result.StatusCode);
        }

    }
}
