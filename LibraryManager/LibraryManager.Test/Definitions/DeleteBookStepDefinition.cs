using LibraryManager.Test.Hooks;
using NUnit.Framework;
using System.Net;
using TechTalk.SpecFlow;

namespace LibraryManager.Test.Definitions
{
    [Binding]
    public sealed class DeleteBookStepDefinition
    {
        [StepDefinition(@"book is deleted (.*)")]
        public void WhenBookIsDeleted(int id)
        {
            BaseHook.result = BaseHook.bookClient.DeleteBook(id);
        }
    }
}
