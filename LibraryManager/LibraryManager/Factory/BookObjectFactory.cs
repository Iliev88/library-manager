namespace LibraryManager.Factory
{
    using LibraryManager.Model;
    using System;

    public class BookObjectFactory
    {
        public static BookModel GetBook()
        {
            var book = new BookModel
            {
                Id = new Random().Next(1, int.MaxValue),
                Title = "Book Name",
                Author = "Author of the Book",
                Description = "Book Description"
            };

            return book;
        }
    }
}
