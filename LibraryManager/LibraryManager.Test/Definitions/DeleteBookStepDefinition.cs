namespace LibraryManager.Test.Definitions
{
    using LibraryManager.Test.Hooks;
    using TechTalk.SpecFlow;

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
