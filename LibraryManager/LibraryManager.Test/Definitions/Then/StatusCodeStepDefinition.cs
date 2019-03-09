namespace LibraryManager.Test.Definitions.Then
{
    using LibraryManager.Test.Hooks;
    using NUnit.Framework;
    using System.Net;
    using TechTalk.SpecFlow;

    [Binding]
    public sealed class StatusCodeStepDefinition
    {
        [Then(@"successful status code should be returned")]
        public void ThenSuccessfulStatusCodeShouldBeReturned()
        {
            Assert.AreEqual(HttpStatusCode.OK, BaseHook.result.Result.StatusCode);
        }

        [Then(@"unsuccessful status code should be returned")]
        public void ThenUnsuccessfulStatusCodeShouldBeReturned()
        {
            Assert.AreEqual(HttpStatusCode.BadRequest, BaseHook.result.Result.StatusCode);
        }

        [Then(@"successful status code for deletion should be returned")]
        public void ThenSuccessfulStatusCodeForDeletionShouldBeReturned()
        {
            Assert.AreEqual(HttpStatusCode.NoContent, BaseHook.result.Result.StatusCode);
        }

        [Then(@"not found status code should be returned")]
        public void ThenNotFoundStatusCodeShouldBeReturned()
        {
            Assert.AreEqual(HttpStatusCode.NotFound, BaseHook.result.Result.StatusCode);
        }
    }
}
