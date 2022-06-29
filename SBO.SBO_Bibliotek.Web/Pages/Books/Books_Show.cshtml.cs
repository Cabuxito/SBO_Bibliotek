using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SBO.SBO_Bibliotek.Services.Models;
using SBO.SBO_Bibliotek.Services.Services.ProductServices;

namespace SBO.SBO_Bibliotek.Web.Pages.Books
{
    public class Books_ShowModel : PageModel
    {
        private readonly IProductService _productService;

        public Books_ShowModel (IProductService productService)
        {
            _productService = productService;
        }

        public List<BooksModel> ListOfBooks { get; set; }

        public void OnGet()
        {
            ListOfBooks = _productService.GetAllBooks();
        }
        public IActionResult OnPostDeleteButton(string isbn)
        {
            _productService.DeleteBooksByISBN(isbn);
            return RedirectToPage("/Books/Books_Show");
        }
    }
}
