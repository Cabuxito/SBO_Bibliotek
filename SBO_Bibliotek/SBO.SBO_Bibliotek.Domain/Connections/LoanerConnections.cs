using SBO.SBO_Bibliotek.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBO.SBO_Bibliotek.Domain.Connections
{
    public class LoanerConnections
    {
        private readonly string _connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Bibliotek;Integrated Security=True";
        private readonly SqlConnection _sqlConnection;

        /// <summary>
        /// ConnectionString constructor.
        /// </summary>
        public LoanerConnections()
        {
            _sqlConnection = new SqlConnection(_connectionString);
        }
        /// <summary>
        /// Create a command method and connection.
        /// </summary>
        /// <param name="StoredProcedure"></param>
        /// <returns></returns>
        public SqlCommand MyCommand(string StoredProcedure)
        {
            SqlCommand myCommand = new SqlCommand(StoredProcedure);
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.Connection = _sqlConnection;
            return myCommand;
        }
        /// <summary>
        /// Add new Loaner to DB with input from user.
        /// </summary>
        /// <param name="ISBN"></param>
        /// <param name="email"></param>
        /// <param name="name"></param>
        /// <param name="phone"></param>
        /// <returns></returns>
        public string AddLoaner(string email, string firstname, string lastname, int phone)
        {
            SqlCommand myCommand = MyCommand("spAddLoaner");
            myCommand.Parameters.AddWithValue("@Email", email);
            myCommand.Parameters.AddWithValue("@FirstName", firstname);
            myCommand.Parameters.AddWithValue("@LastName", lastname);
            myCommand.Parameters.AddWithValue("@Phone", phone);
            _sqlConnection.Open();
            myCommand.ExecuteNonQuery();
            _sqlConnection.Close();
            return "Loaner was added.";
        }
        /// <summary>
        /// Show all Loaners.
        /// </summary>
        /// <returns></returns>
        public List<Loaner> GetAllLoaners()
        {
            SqlCommand myCommand = MyCommand("spGetAllLoaner");
            try
            {
                _sqlConnection.Open();
                SqlDataReader myReader = myCommand.ExecuteReader();
                if ( myReader.HasRows )
                {
                    List<Loaner> loaners = new List<Loaner>();
                    while ( myReader.Read() )
                    {
                        loaners.Add(new Loaner
                        {
                            LoanerId = myReader.GetInt32(0),
                            FirstName = myReader.GetString(1),
                            LastName = myReader.GetString(2),
                            LoanerEmail = myReader.GetString(3),
                            LoanerPhone = myReader.GetInt32(4),
                            LoanerBook = myReader.GetString(5),

                        });
                    }
                    return loaners;
                }
            }
            finally
            {
                _sqlConnection.Close();
            }
            return null;
        }
        /// <summary>
        /// Get one loaner by input loaner ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Loaner GetLoanerById(int id)
        {
            SqlCommand myCommand = MyCommand("@GetLoanerById");
            myCommand.Parameters.AddWithValue("@id", id);
            try
            {
                _sqlConnection.Open();
                SqlDataReader myReader = myCommand.ExecuteReader();
                if ( myReader.HasRows )
                {
                    while ( myReader.Read() )
                    {
                        Loaner loaner = new Loaner
                        {
                            ISBN = myReader.GetString(0),
                            LoanerEmail = myReader.GetString(1),
                            FirstName = myReader.GetString(2),
                            LastName = myReader.GetString(3),
                            LoanerPhone = myReader.GetInt32(4)
                        };
                        return loaner;
                    }
                }
            }
            finally
            {
                _sqlConnection.Close();
            }
            return null;
        }
        /// <summary>
        /// Loan a book to a loaner by input ISBN.
        /// </summary>
        /// <param name="ISBN"></param>
        /// <param name="loaner_id"></param>
        /// <returns>message to loaner.</returns>
        public string LoanBookToLoaner(string ISBN, int loaner_id)
        {
            SqlCommand myCommand = MyCommand("spLoanBookToLoaner");
            myCommand.Parameters.AddWithValue("@ISBN", ISBN);
            myCommand.Parameters.AddWithValue("@Loaner_id", loaner_id);
            try
            {
                _sqlConnection.Open();
                myCommand.ExecuteNonQuery();
            }
            finally
            {
                _sqlConnection.Close();
            }
            return "Succes, you have loan a book";
        }
        /// <summary>
        /// Remove Book from Loaner by input af Loaner_id.
        /// </summary>
        /// <param name="LoanerId"></param>
        /// <returns>string</returns>
        public string RemoveBookFromLoaner(int LoanerId)
        {
            SqlCommand myCommand = MyCommand("spRemoveBookFromLoaner");
            myCommand.Parameters.AddWithValue("@Loaner_id", LoanerId);
            try
            {
                _sqlConnection.Open();
                myCommand.ExecuteNonQuery();
            }
            finally
            {
                _sqlConnection.Close();
            }
            return "Book was returned.";
        }
    }
}
