using LibraryManager.Factory;
using LibraryManager.Model;
using NUnit.Framework;
using System.Net;

namespace LibraryManager.Test
{
    [TestFixture]
    public class BookTest : BaseTest
    {
        [Test]
        public void GetBooks_MustReturnAllBooks()
        {
            var result = bookClient.GetAllBooks(null);
            var responseModel = httpRequestHandler.HandleHttpRequest<BookModel[]>(result);
            
        }

        [Test]
        public void GetBookById_MustReturnValidBook()
        {
            var result = bookClient.GetBook(1);
            var responseModel = httpRequestHandler.GetHttpRequestMsgAsString(result);
        
            Assert.IsNotNull(responseModel);
        }

        [Test]
        public void AddBook_MustAddBookSuccessfully()
        {
            var book = BookObjectFactory.GetBook();

            var result = bookClient.AddBook(book);
            var responseModel = httpRequestHandler.HandleHttpRequest<BookModel>(result);

            Assert.Multiple(() =>
            {
                Assert.That(responseModel.Id, Is.EqualTo(book.Id), "'Id' is missing or is not equal to");
                Assert.That(responseModel.Author, Is.EqualTo(book.Author), "'Author' is missing or is not equal to");
                Assert.That(responseModel.Title, Is.EqualTo(book.Title), "'Title' is missing or is not equal to");
                Assert.That(responseModel.Description, Is.EqualTo(book.Description), "'Description' is missing or is not equal to");
            });
        }

        [Test]
        public void UpdateBook_MustUpdateBookSuccessfully()
        {
            var book = BookObjectFactory.GetBook();

            var addBook = bookClient.AddBook(book);
            var addBookResponseModel = httpRequestHandler.HandleHttpRequest<BookModel>(addBook);

            var updatedBook = book;
            updatedBook.Title = updatedBook.Title + "[edit]";
            updatedBook.Author = updatedBook.Author + "[edit]";
            updatedBook.Description = updatedBook.Description + "[edit]";

            var updateBook = bookClient.UpdateBook(addBookResponseModel.Id, updatedBook);
            var updatedBookResponseModel = httpRequestHandler.HandleHttpRequest<BookModel>(updateBook);

            Assert.Multiple(() =>
            {
                Assert.That(updatedBookResponseModel.Id, Is.EqualTo(updatedBook.Id), "'Id' is missing or is not equal to");
                Assert.That(updatedBookResponseModel.Author, Is.EqualTo(updatedBook.Author), "'Author' is missing or is not equal to");
                Assert.That(updatedBookResponseModel.Title, Is.EqualTo(updatedBook.Title), "'Title' is missing or is not equal to");
                Assert.That(updatedBookResponseModel.Description, Is.EqualTo(updatedBook.Description), "'Description' is missing or is not equal to");
            });
        }

        [Test]
        public void DeleteBook_MustDeleteBookSuccessfully()
        {
            var book = BookObjectFactory.GetBook();

            var addBook = bookClient.AddBook(book);
            var addBookResponseModel = httpRequestHandler.HandleHttpRequest<BookModel>(addBook);

            var deleteBook = bookClient.DeleteBook(addBookResponseModel.Id);

            Assert.AreEqual(HttpStatusCode.NoContent, deleteBook.Result.StatusCode);
        }
    }
}
