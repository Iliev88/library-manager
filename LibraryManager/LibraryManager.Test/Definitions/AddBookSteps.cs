using System.Net;
using LibraryManager.Model;
using LibraryManager.Test.Hooks;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace LibraryManager.Test.Definitions
{
    [Binding]
    public class AddBookSteps
    {
        private BookModel _book;
        private BookModel _responseModel;
        private ResponseErrorModel _responseErrorModel;
        private HttpStatusCode _statusCode;

        [Given(@"I create a new valid book \((.*), (.*), (.*), (.*)\)")]
        public void GivenICreateANewValidBook(int Id, string Title, string Author, string Description)
        {
            BookModel book = new BookModel()
            {
                Id = Id,
                Author = Author,
                Title = Title,
                Description = Description
            };

            var result = BaseHook.bookClient.AddBook(_book);
            _statusCode = result.Result.StatusCode;
            _responseModel = BaseHook.httpRequestHandler.HandleHttpRequest<BookModel>(result);
        }

        [Given(@"I create a new invalid book \((.*), (.*), (.*), (.*)\)")]
        public void GivenICreateANewInvalidBook(int Id, string Title, string Author, string Description)
        {
            _book = new BookModel()
            {
                Id = Id,
                Author = Author,
                Title = Title,
                Description = Description
            };

            var result = BaseHook.bookClient.AddBook(_book);
            _statusCode = result.Result.StatusCode;
            _responseErrorModel = BaseHook.httpRequestHandler.HandleHttpRequest<ResponseErrorModel>(result);
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

        [Then(@"the system should return positive (.*)")]
        public void ThenTheSystemShouldReturnPositive(string p0)
        {
            Assert.AreEqual(HttpStatusCode.OK, _statusCode);
        }

        [Then(@"the system should return negative (.*)")]
        public void ThenTheSystemShouldReturnNegative(string p0)
        {
            Assert.AreEqual(HttpStatusCode.BadRequest, _statusCode);
        }

        [Then(@"error message should be returned as well")]
        public void ThenErrorMessageMustBeReturnedAsWell()
        {
            Assert.That(_responseErrorModel.ErrorMessage, Is.Not.Null);
        }
    }
}
