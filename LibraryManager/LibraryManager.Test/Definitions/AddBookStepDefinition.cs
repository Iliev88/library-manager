namespace LibraryManager.Test.Definitions
{
    using System;
    using System.Net;
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
            this.bookModel = book;
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

        [When(@"the model is sent to the server")]
        [Given(@"the model is sent to the server")]
        public void WhenTheModelIsSentToTheServer()
        {
            BaseHook.result = BaseHook.bookClient.AddBook(bookModel);
        }

        [Then(@"the book should be added")]
        [Given(@"the book should be added")]
        public void ThenTheBookShouldBeAdded()
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

        [Then(@"the book should not be added (.*)")]
        public void ThenTheBookShouldNotBeAdded(string error)
        {
            var errorMessage = BaseHook.httpRequestHandler.GetHttpRequestMsgAsString(BaseHook.result);

            Assert.That(errorMessage, Does.Contain(error));
            Console.WriteLine(errorMessage);
        }

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


    }
}
