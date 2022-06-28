using SBO.SBO_Bibliotek.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBO.SBO_Bibliotek.Services.Services.UserServices
{
    public interface IUserService
    {
        public string AddAuthors(AuthorsModel Author);
        public List<AuthorsModel> GetAllAuthors();
        public AuthorsModel GetAuthorsByName(string name);
        public string AddLoaner(LoanerModel Loaner);
        public List<LoanerModel> GetAllLoaners();
        public LoanerModel GetLoanerById(int id);
        public string RemoveBookFromLoaner(int LoanerId);
    }
}
