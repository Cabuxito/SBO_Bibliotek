using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SBO.SBO_Bibliotek.Services.Services.ProductServices;

namespace SBO.SBO_Bibliotek.Web.Pages.Books
{
    public class Books_CreateModel : PageModel
    {
        ProductService myServices = new ProductService();

        [BindProperty]
        public string ISBN { get; set; }
        [BindProperty]
        public string Title { get; set; }
        [BindProperty]
        public string Year { get; set; }
        [BindProperty]
        public string Publisher { get; set; }
        [BindProperty]
        public string Genre { get; set; }
        [BindProperty]
        public string Author { get; set; }

        public IActionResult OnPost()
        {
            myServices.AddBook(ISBN, Title, Year, Publisher, Genre, Author);
            return RedirectToPage("/Books/Books_Create");
        }
    }
}
