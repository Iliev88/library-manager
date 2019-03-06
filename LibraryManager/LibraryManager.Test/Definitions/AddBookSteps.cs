using LibraryManager.Client;
using LibraryManager.Model;
using NUnit.Framework;
using System;
using System.Net;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Utilities;

namespace LibraryManager.Test.Definitions
{
    [Binding]
    public class AddBookSteps
    {
        private BookModel _book;
        private BookClient _bookClient;
        private HttpRequestHandler _httpRequestHandler;
        private BookModel _responseModel;
        private HttpStatusCode _statusCode;

        public AddBookSteps()
        {
            _bookClient = new BookClient();
            _httpRequestHandler = new HttpRequestHandler();
        }

        [Given(@"I create a new book \((.*), (.*), (.*), (.*)\)")]
        public void GivenICreateANewBook(int Id, string Title, string Author, string Description)
        {
            _book = new BookModel()
            {
                Id = Id,
                Author = Author,
                Title = Title,
                Description = Description
            };

            var result = _bookClient.AddBook(_book);
            _responseModel = _httpRequestHandler.HandleHttpRequest<BookModel>(result);
        }

        [Given(@"ModelState is correct")]
        public void GivenModelStateIsCorrect()
        {
            Assert.Multiple(() =>
            {
                Assert.That(_responseModel.Id, Is.EqualTo(_book.Id), "'Id' is missing or is not equal to");
                Assert.That(_responseModel.Author, Is.EqualTo(_book.Author), "'Author' is missing or is not equal to");
                Assert.That(_responseModel.Title, Is.EqualTo(_book.Title), "'Title' is missing or is not equal to");
                Assert.That(_responseModel.Description, Is.EqualTo(_book.Description), "'Description' is missing or is not equal to");
            });
        }
        
        [Then(@"the system should return (.*)")]
        public void ThenTheSystemShouldReturn(string p0)
        {
            Assert.AreEqual(_statusCode, HttpStatusCode.OK);
        }
    }
}
