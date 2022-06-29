using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SBO.SBO_Bibliotek.Services.Models;
using SBO.SBO_Bibliotek.Services.Services.ProductServices;

namespace SBO.SBO_Bibliotek.Web.Pages.Books
{
    public class Books_UpdateModel : PageModel
    {
        private readonly IProductService _productService;

        public Books_UpdateModel(IProductService productService)
        {
            _productService = productService;
        }
        
        [BindProperty(SupportsGet = true)]
        public string UpdateISBN { get; set; }
        [BindProperty]
        public string UpdateTitle { get; set; }
        [BindProperty]
        public string UpdateYear { get; set; }
        [BindProperty]
        public string UpdatePublisher { get; set; }
        [BindProperty]
        public string UpdateGenre { get; set; }
        [BindProperty]
        public string UpdateAuthor { get; set; }
        [BindProperty]
        public BooksModel MyBooksModel { get; set; } 
        
        public void OnGet()
        {
            _productService.GetBooksInfoByISBN(UpdateISBN);
        }

    }
}
