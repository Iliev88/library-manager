using LibraryManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace LibraryManager.Client
{
    public class BookClient : BaseClient
    {
        public Task<HttpResponseMessage> GetAllBooks(string title)
        {
            using (var client = new HttpClient())
            {
                var builder = new UriBuilder($"{libraryManagerSettings.BaseUrl}/api/books?title={title}");
                var query = HttpUtility.ParseQueryString(builder.Query);
                if (title != null)
                { query["title"] = title; }
                builder.Query = query.ToString();
                var url = builder.ToString();

                Task<HttpResponseMessage> response = client.GetAsync(url);

                response.Wait();
                return response;
            }
        }

        public Task<HttpResponseMessage> GetBook(int bookId)
        {
            using (var client = new HttpClient())
            {
                var url = $"{libraryManagerSettings.BaseUrl}/api/books/{bookId}";
                Task<HttpResponseMessage> response = client.GetAsync(url);

                response.Wait();
                return response;
            }
        }

        public Task<HttpResponseMessage> AddBook(BookModel bookModel)
        {
            using (var client = new HttpClient())
            {
                var url = $"{libraryManagerSettings.BaseUrl}/api/books";
                Task<HttpResponseMessage> response = client.PostAsJsonAsync(url, bookModel);

                response.Wait();
                return response;
            }
        }

        public Task<HttpResponseMessage> UpdateBook(int bookId, BookModel bookModel)
        {
            using (var client = new HttpClient())
            {
                var url = $"{libraryManagerSettings.BaseUrl}/api/books/{bookId}";
                Task<HttpResponseMessage> response = client.PutAsJsonAsync(url, bookModel);

                response.Wait();
                return response;
            }
        }

        public Task<HttpResponseMessage> DeleteBook(int bookId)
        {
            using (var client = new HttpClient())
            {
                var url = $"{libraryManagerSettings.BaseUrl}/api/books/{bookId}";
                Task<HttpResponseMessage> response = client.DeleteAsync(url);

                response.Wait();
                return response;
            }
        }
    }
}
