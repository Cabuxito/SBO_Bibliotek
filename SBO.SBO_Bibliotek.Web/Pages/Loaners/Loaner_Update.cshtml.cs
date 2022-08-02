using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SBO.SBO_Bibliotek.Services.Models;
using SBO.SBO_Bibliotek.Services.Services.UserServices;

namespace SBO.SBO_Bibliotek.Web.Pages.Loaners
{
    public class Loaner_UpdateModel : PageModel
    {
        private readonly IUserService _userService;

        public Loaner_UpdateModel (IUserService userService)
        {
            _userService = userService;
        }

        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public string Name { get; set; }
        [BindProperty]
        public string LastName { get; set; }
        [BindProperty]
        public int Phone { get; set; }
        [BindProperty]
        public string LoanerBook { get; set; }
        [BindProperty]
        public LoanerModel myLoanerModel { get; set; }
        
        public void OnGet()
        {
            
        }
    }
}
