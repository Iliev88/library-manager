namespace LibraryManager.Test.Definitions
{
    using LibraryManager.Factory;
    using LibraryManager.Model;
    using LibraryManager.Test.Hooks;
    using NUnit.Framework;
    using TechTalk.SpecFlow;

    [Binding]
    public sealed class AddBookStepDefinition
    {
        public BookModel bookModel;

        public AddBookStepDefinition(BookModel book)
        {
            bookModel = book;
        }

        [Given(@"book model is created (.*), (.*), (.*) and (.*)")]
        public void GivenBookModelIsCreated(int id, string author, string title, string description)
        {
            bookModel = BookObjectFactory.GetBook();
            bookModel.Id = id;
            bookModel.Author = author;
            bookModel.Title = title;
            bookModel.Description = description;
        }

        [StepDefinition(@"the model is sent to the server")]
        public void WhenTheModelIsSentToTheServer()
        {
            BaseHook.result = BaseHook.bookClient.AddBook(bookModel);
        }

        [StepDefinition(@"the book should be available")]
        public void ThenTheBookShouldBeAvailable()
        {
            var responseModel = BaseHook.httpRequestHandler.HandleHttpRequest<BookModel>(BaseHook.result);

            Assert.Multiple(() =>
            {
                Assert.That(responseModel.Id, Is.EqualTo(bookModel.Id), "'Id' is missing or is not equal to");
                Assert.That(responseModel.Author, Is.EqualTo(bookModel.Author), "'Author' is missing or is not equal to");
                Assert.That(responseModel.Title, Is.EqualTo(bookModel.Title), "'Title' is missing or is not equal to");
                Assert.That(responseModel.Description, Is.EqualTo(bookModel.Description), "'Description' is missing or is not equal to");
            });
        }
    }
}
