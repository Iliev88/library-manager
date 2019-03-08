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
    public sealed class UpdateBookStepDefinition
    {
        public BookModel bookModel;

        public UpdateBookStepDefinition(BookModel book)
        {
            this.bookModel = book;
        }

        [When(@"the book is updated (.*), (.*), (.*), (.*)")]
        public void WhenTheBookIsUpdated(int id, string author, string title, string description)
        {
            bookModel = BookObjectFactory.GetBook();
            bookModel.Id = id;
            bookModel.Author = author;
            bookModel.Title = title;
            bookModel.Description = description;

            BaseHook.result = BaseHook.bookClient.UpdateBook(id, bookModel);
        }

        [Then(@"updated book should be returned as well")]
        public void ThenUpdatedBookShouldBeReturnedAsWell()
        {
            var responseModel = BaseHook.httpRequestHandler.HandleHttpRequest<BookModel>(BaseHook.result);

            Assert.Multiple(() =>
            {
                Console.WriteLine(responseModel.Author);
                Assert.That(responseModel.Id, Is.EqualTo(bookModel.Id), "'Id' is missing or is not equal to");
                Assert.That(responseModel.Author, Is.EqualTo(bookModel.Author), "'Author' is missing or is not equal to");
                Assert.That(responseModel.Title, Is.EqualTo(bookModel.Title), "'Title' is missing or is not equal to");
                Assert.That(responseModel.Description, Is.EqualTo(bookModel.Description), "'Description' is missing or is not equal to");
            });
        }

    }
}
