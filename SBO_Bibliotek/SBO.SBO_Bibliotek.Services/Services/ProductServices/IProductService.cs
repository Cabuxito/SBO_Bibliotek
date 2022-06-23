using SBO.SBO_Bibliotek.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBO.SBO_Bibliotek.Services.Services.ProductServices
{
    public interface IProductService
    {
        public string DeleteAuthorById(int id);
        public string DeleteGenreById(int id);
        public List<Books> GetAllBooks();
        public Books GetBookByISBN(string id);
        public string AddBook(string ISBN, string bookname, int bookQuantity);
        public string AddGenre(string genreName);
    }
}
