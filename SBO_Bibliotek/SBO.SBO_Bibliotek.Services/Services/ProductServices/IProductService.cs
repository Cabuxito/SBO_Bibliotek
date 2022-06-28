using SBO.SBO_Bibliotek.Domain.Entities;
using SBO.SBO_Bibliotek.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBO.SBO_Bibliotek.Services.Services.ProductServices
{
    public interface IProductService
    {
        public string AddBook(string ISBN, string booktitle, string publication, string publisher, string genrename, string author);
        public List<BooksModel> GetAllBooks();
        public BooksModel GetBookByISBN(string ISBN);
        public string AddGenre(string genrename);
        public string DeleteBooksByISBN(string ISBN);
        public BooksModel GetBooksInfoByISBN(string ISBN);
    }
}
