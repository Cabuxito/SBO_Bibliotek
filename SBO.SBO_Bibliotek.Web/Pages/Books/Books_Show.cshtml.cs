using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SBO.SBO_Bibliotek.Services.Models;
using SBO.SBO_Bibliotek.Services.Services.ProductServices;

namespace SBO.SBO_Bibliotek.Web.Pages.Books
{
    public class Books_ShowModel : PageModel
    {
        ProductService myBookService = new ProductService();

        public List<BooksModel> ListOfBooks { get; set; }

        public void OnGet()
        {
            ProductService Books = new ProductService();

            ListOfBooks = Books.GetAllBooks();

        }
        public IActionResult OnPostDeleteButton(string isbn)
        {
            myBookService.DeleteBooksByISBN(isbn);
            return RedirectToPage("/Books/Books_Show");
        }
    }
}
