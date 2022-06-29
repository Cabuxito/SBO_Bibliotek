using SBO.SBO_Bibliotek.Domain.Connections;
using SBO.SBO_Bibliotek.Domain.Entities;
using SBO.SBO_Bibliotek.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBO.SBO_Bibliotek.Services.Services.ProductServices
{
    public class ProductService : IProductService
    {
        #region Books

        public string AddBook(string ISBN, string booktitle, string publication, string publisher, string genrename, string author)
        {
            BooksConnections booksConnections = new BooksConnections();
            return booksConnections.AddBook(ISBN, booktitle, publication, publisher, genrename, author);
        }

        public List<BooksModel> GetAllBooks()
        {
            BooksConnections booksConnections = new BooksConnections();
            List<Books> listOfBooks = booksConnections.GetAllBooks();
            List<BooksModel> books = new List<BooksModel>();
            foreach ( var item in listOfBooks )
            {
                books.Add(new BooksModel
                {
                    ISBN = item.ISBN,
                    Title = item.Book_Title,
                    Publication = item.Publication,
                    Publisher = item.Publisher,
                    Genre = item.Genre_Name,
                    Author = item.Author_Name
                });
            }
            return books;
        }

        public BooksModel GetBookByISBN(string ISBN)
        {
            BooksConnections booksConnections = new BooksConnections();
            Books listOfBooks = booksConnections.GetBookByISBN(ISBN);
            BooksModel books = new BooksModel
            {
                ISBN = listOfBooks.ISBN,
                Title = listOfBooks.Book_Title,
                Publication = listOfBooks.Publication,
                Publisher = listOfBooks.Publisher
            };
            return books;
        }

        public string DeleteBooksByISBN(string ISBN)
        {
            BooksConnections productService = new BooksConnections();
            return productService.DeleteBookByISBN(ISBN);
        }

        public BooksModel GetBooksInfoByISBN(string ISBN)
        {
            BooksConnections productService = new BooksConnections();
            Books listOfBooks = productService.GetBooksInfoByISBN(ISBN);
            BooksModel bookInfo = new BooksModel
            {
                ISBN = listOfBooks.ISBN,
                Author = listOfBooks.Author_Name,
                Genre = listOfBooks.Genre_Name,
                Publication = listOfBooks.Publication,
                Publisher = listOfBooks.Publisher,
                Title = listOfBooks.Book_Title
            };
            return bookInfo;
        }

        #endregion

        #region Genre

        public string AddGenre(string genrename)
        {
            GenreConnections genreConnections = new GenreConnections();
            return genreConnections.AddGenre(genrename);
        }

        #endregion
    }
}
