using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SBO.SBO_Bibliotek.Services.Models;
using SBO.SBO_Bibliotek.Services.Services.UserServices;

namespace SBO.SBO_Bibliotek.Web.Pages.Loaners
{
    public class Loaner_ShowModel : PageModel
    {
        private readonly IUserService _userService;

        public Loaner_ShowModel (IUserService userService)
        {
            _userService = userService;
        }

        public List<LoanerModel> myLoaners { get; set; }

        public void OnGet()
        {
            myLoaners = _userService.GetAllLoaners();
        }
    }
}
