namespace LibraryManager.Test.Definitions
{
    using LibraryManager.Test.Hooks;
    using TechTalk.SpecFlow;

    [Binding]
    public sealed class GetBookStepDefinition
    {
        [StepDefinition(@"book is requested (.*)")]
        public void GivenBookIsRequested(int id)
        {
            BaseHook.result = BaseHook.bookClient.GetBook(id);
        }
    }
}
