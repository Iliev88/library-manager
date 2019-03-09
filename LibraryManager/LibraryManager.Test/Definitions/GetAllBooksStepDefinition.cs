using LibraryManager.Factory;
using LibraryManager.Model;
using LibraryManager.Test.Hooks;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace LibraryManager.Test.Definitions
{
    [Binding]
    public sealed class GetAllBooksStepDefinition
    {
        public BookModel bookModel;

        public GetAllBooksStepDefinition(BookModel book)
        {
            bookModel = book;
        }

        [Given(@"a new book model is created (.*), (.*), (.*) and (.*)")]
        public void GivenANewBookModelIsCreated(int id, string author, string title, string description)
        {
            bookModel = BookObjectFactory.GetBook();
            bookModel.Id = id;
            bookModel.Author = author;
            bookModel.Title = title;
            bookModel.Description = description;
        }

        [Given(@"the new model is sent to the server")]
        public void WhenTheNewModelIsSentToTheServer()
        {
            BaseHook.result = BaseHook.bookClient.AddBook(bookModel);
        }

        [When(@"the books are requested")]
        public void WhenTheBooksAreRequested()
        {
            BaseHook.result = BaseHook.bookClient.GetAllBooks(null);
        }

        [Then(@"all books should be retrieved")]
        public void ThenAllBooksShouldBeRetrieved()
        {
            var responseModel = BaseHook.httpRequestHandler.HandleHttpRequest<BookModel[]>(BaseHook.result);

            Assert.Multiple(() =>
            {
                foreach (var book in responseModel)
                {
                    Assert.That(book.Id, Is.Not.Null, "'Id' is missing");
                    Assert.That(book.Author, Is.Not.Null, "'Author' is missing");
                    Assert.That(book.Title, Is.Not.Null, "'Title' is missing");
                    Assert.That(book.Description, Is.Not.Null, "'Description' is missing");
                }
            });
        }

    }
}
