using SBO.SBO_Bibliotek.Domain.Connections;
using SBO.SBO_Bibliotek.Domain.Entities;
using SBO.SBO_Bibliotek.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBO.SBO_Bibliotek.Services.Services.UserServices
{
    public class UserService
    {
        #region Authors

        /// <summary>
        /// Connect to Domain.AddAuthors and send some properties.
        /// </summary>
        /// <param name="authorname"></param>
        /// <param name="publisher"></param>
        /// <returns>AddAuthors Method</returns>
        public string AddAuthors (AuthorsModel Author)
        {
            AuthorConnections AuthorConnection = new AuthorConnections();
            return AuthorConnection.AddAuthors(Author.AuthorsName);
        }

        public AuthorsModel GetAuthorByName (string name)
        {
            AuthorConnections AuthorConnection = new AuthorConnections();
            Authors authors = AuthorConnection.GetAuthorsByName(name);
            AuthorsModel mymodel = new AuthorsModel 
            { 
                AuthorsName = authors.AuthorsName
            };
            return mymodel;
        }

        public List<AuthorsModel> GetAllAuthors()
        {
            AuthorConnections AuthorConnection = new AuthorConnections();
            List<AuthorsModel> AuthorList = new List<AuthorsModel>();
            List<Authors> AllAuthors = AuthorConnection.GetAllAuthors();
            foreach ( Authors item in AllAuthors )
            {
                AuthorList.Add(new AuthorsModel 
                {
                    AuthorsName = item.AuthorsName
                });
            }
            return AuthorList;
        }

        public string DeleteAuthorById(int id)
        {
            AuthorConnections authorConnection = new AuthorConnections();
            return authorConnection.DeleteAuthorById(id);
        }
        #endregion

        #region Loaner

        public string AddLoaner(LoanerModel Loaner) 
        {
            LoanerConnections loanerConnections = new LoanerConnections();
            return loanerConnections.AddLoaner(Loaner.LoanerEmail, Loaner.LoanerFirstname,Loaner.LoanerLastname, Loaner.LoanerPhone);
        }

        public LoanerModel GetLoanerById (int Id)
        {
            LoanerConnections loanerConnection = new LoanerConnections();
            Loaner loaners = loanerConnection.GetLoanerById(Id);
            LoanerModel myModel = new LoanerModel
            {
                LoanerEmail = loaners.LoanerEmail,
                LoanerFirstname = loaners.FirstName,
                LoanerLastname = loaners.LastName,
                LoanerPhone = loaners.LoanerPhone
            };
            return myModel;
        }

        public List<LoanerModel> GetAllLoaners()
        {
            LoanerConnections loanerConnections = new LoanerConnections();
            List<Loaner> AllLoaner = loanerConnections.GetAllLoaners();
            List<LoanerModel> loanerList = new List<LoanerModel>();
            foreach ( Loaner item in AllLoaner )
            {
                loanerList.Add(new LoanerModel
                {
                    LoanerEmail = item.LoanerEmail,
                    LoanerFirstname = item.FirstName,
                    LoanerLastname = item.LastName,
                    LoanerPhone = item.LoanerPhone
                });
            }
            return loanerList;
        }

        public string RemoveBookFromLoaner (int Id)
        {
            LoanerConnections loanerConnections = new LoanerConnections();
            return loanerConnections.RemoveBookFromLoaner(Id);
        }

        #endregion

    }
}
