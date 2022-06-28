using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBO.SBO_Bibliotek.Domain.Entities;

namespace SBO.SBO_Bibliotek.Domain.Connections
{
    public class BooksConnections
    {
        private readonly string _connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Bibliotek;Integrated Security=True";
        private readonly SqlConnection _sqlConnection;

        /// <summary>
        /// ConnectionString constructor.
        /// </summary>
        public BooksConnections()
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
        /// Add new Book to DB with input from user.
        /// </summary>
        /// <param name="ISBN"></param>
        /// <param name="bookname"></param>
        /// <param name="bookQuantity"></param>
        /// <returns></returns>
        public string AddBook(string ISBN, string booktitle, string publication, string publisher, string genrename, string author)
        {
            SqlCommand myCommand = MyCommand("spAddBooks");
            myCommand.Parameters.AddWithValue("@ISBN", ISBN);
            myCommand.Parameters.AddWithValue("@Title", booktitle);
            myCommand.Parameters.AddWithValue("@Publication", publication);
            myCommand.Parameters.AddWithValue("@Publisher", publisher);
            myCommand.Parameters.AddWithValue("@Genre_Name", genrename);
            myCommand.Parameters.AddWithValue("@Author_Name", author);
            _sqlConnection.Open();
            myCommand.ExecuteNonQuery();
            _sqlConnection.Close();
            return "Book was added.";
        }
        /// <summary>
        /// Show all Books.
        /// </summary>
        /// <returns></returns>
        public List<Books> GetAllBooks()
        {
            SqlCommand myCommand = MyCommand("spGetAllBooks");
            try
            {
                _sqlConnection.Open();
                SqlDataReader myReader = myCommand.ExecuteReader();
                if ( myReader.HasRows )
                {
                    List<Books> Books = new List<Books>();
                    while ( myReader.Read() )
                    {
                        Books.Add(new Books
                        {
                            ISBN = myReader.GetString(0),
                            Book_Title = myReader.GetString(1),
                            Publication = myReader.GetDateTime(2).Year.ToString(),
                            Publisher = myReader.GetString(3),
                            Genre_Name = myReader.GetString(4),
                            Author_Name = myReader.GetString(5)
                        }); ;
                    }
                    return Books;
                }
            }
            finally
            {
                _sqlConnection.Close();
            }
            return null;
        }
        /// <summary>
        /// Show Book by input ISBN (International Standard Book Number).
        /// </summary>
        /// <param name="id"></param>
        /// <returns>OneBook</returns>
        public Books GetBookByISBN(string ISBN)
        {
            SqlCommand myCommand = MyCommand("spGetBooksByISBN");
            myCommand.Parameters.AddWithValue("@ISBN", ISBN);
            try
            {
                _sqlConnection.Open();
                SqlDataReader myReader = myCommand.ExecuteReader();
                if ( myReader.HasRows )
                {
                    while ( myReader.Read() )
                    {
                        Books oneBook = new Books
                        {
                            ISBN = myReader.GetString(0),
                            Book_Title = myReader.GetString(1),
                            Publication = myReader.GetDateTime(2).ToString(),
                            Publisher = myReader.GetString(3)
                        };
                        return oneBook;
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
        /// Delete one book by input af ISBN.
        /// </summary>
        /// <param name="ISBN"></param>
        /// <returns></returns>
        public string DeleteBookByISBN(string ISBN)
        {
            SqlCommand myCommand = MyCommand("spDeleteBookByISBN");
            myCommand.Parameters.AddWithValue("@ISBN", ISBN);
            try
            {
                _sqlConnection.Open();
                myCommand.ExecuteNonQuery();
            }
            finally
            {
                _sqlConnection.Close();
            }
            return "Book was deleted.";
        }

        public Books GetBooksInfoByISBN(string ISBN)
        {
            SqlCommand myCommand = MyCommand("spGetAllBookInfoByISBN");
            myCommand.Parameters.AddWithValue("@ISBN", ISBN);
            try
            {
                _sqlConnection.Open();
                SqlDataReader myReader = myCommand.ExecuteReader();
                if ( myReader.HasRows )
                {
                    while ( myReader.Read() )
                    {
                        Books books = new Books
                        {
                            ISBN = myReader.GetString("ISBN"),
                            Genre_Name = myReader.GetString("Genre_name"),
                            Publication = myReader.GetDateTime("Book_Publication").ToShortDateString(),
                            Publisher = myReader.GetString("Book_Publisher"),
                            Book_Title = myReader.GetString("Book_Title"),
                            Author_Name = myReader.GetString("Authors_Name"),
                        };
                        return books;
                    }
                }
            }
            finally
            {
                _sqlConnection.Close();
            }
            return null;
        }
    }
}
