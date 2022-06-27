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
    public class AuthorConnections
    {
        private readonly string _connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Bibliotek;Integrated Security=True";
        private readonly SqlConnection _sqlConnection;

        /// <summary>
        /// ConnectionString constructor.
        /// </summary>
        public AuthorConnections()
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
        /// Add new Authors to DB with input from user.
        /// </summary>
        /// <param name="authorname"></param>
        /// <param name="publisher"></param>
        /// <returns></returns>
        public string AddAuthors(string authorname)
        {

            SqlCommand myCommand = MyCommand("spAddAuthors");
            myCommand.Parameters.AddWithValue("@Name", authorname);
            _sqlConnection.Open();
            myCommand.ExecuteNonQuery();
            _sqlConnection.Close();
            return "Author was added.";
        }
        /// <summary>
        /// Show all Authors.
        /// </summary>
        /// <returns></returns>
        public List<Authors> GetAllAuthors()
        {
            SqlCommand myCommand = MyCommand("spGetAllAuthors");
            try
            {
                _sqlConnection.Open();
                SqlDataReader myReader = myCommand.ExecuteReader();
                if ( myReader.HasRows )
                {
                    List<Authors> authors = new List<Authors>();
                    while ( myReader.Read() )
                    {
                        authors.Add(new Authors
                        {
                            AuthorsName = myReader.GetString(1)
                        });
                    }
                    return authors;
                }
            }
            finally
            {
                _sqlConnection.Close();
            }
            return null;
        }
        /// <summary>
        /// Show Author by input name or lastname.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Authors GetAuthorsByName(string name)
        {
            SqlCommand myCommand = MyCommand("spGetAuthorsByName");
            myCommand.Parameters.AddWithValue("@Author_Name", name);
            try
            {
                _sqlConnection.Open();
                SqlDataReader myReader = myCommand.ExecuteReader();
                if ( myReader.HasRows )
                {
                    while ( myReader.Read() )
                    {
                        Authors oneAuthor = new Authors
                        {
                            AuthorsName = myReader.GetString(1)
                        };
                        return oneAuthor;
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
        /// Delete Author by input id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string DeleteAuthorById(int id)
        {
            SqlCommand myCommand = MyCommand("spDeleteAuthorById");
            myCommand.Parameters.AddWithValue("@Author_id", id);
            try
            {
                _sqlConnection.Open();
                myCommand.ExecuteNonQuery();
            }
            finally
            {
                _sqlConnection.Close();
            }
            return "Author was deleted.";
        }

    }
}
