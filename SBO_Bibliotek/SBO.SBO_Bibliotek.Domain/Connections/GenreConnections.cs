using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBO.SBO_Bibliotek.Domain.Connections

{
    public class GenreConnections
    {
        private readonly string _connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Bibliotek;Integrated Security=True";
        private readonly SqlConnection _sqlConnection;

        /// <summary>
        /// ConnectionString constructor.
        /// </summary>
        public GenreConnections()
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
        /// Add new Genre to DB with input from user.
        /// </summary>
        /// <param name="genreName"></param>
        /// <returns></returns>
        public string AddGenre(string genreName)
        {
            SqlCommand myCommand = MyCommand("spAddGenre");
            myCommand.Parameters.AddWithValue("Genre_Name", genreName);
            _sqlConnection.Open();
            myCommand.ExecuteNonQuery();
            _sqlConnection.Close();
            return "Genre was added.";
        }
        /// <summary>
        /// Delete one Genre by input ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>"Succes"</returns>
        public string DeleteGenreById(int id)
        {
            SqlCommand mycommand = MyCommand("spDeleteGenreById");
            mycommand.Parameters.AddWithValue("@Genre_id", id);
            try
            {
                _sqlConnection.Open();
                mycommand.ExecuteNonQuery();

            }
            finally
            {
                _sqlConnection.Close();
            }
            return "Genre was deleted.";
        }
    }
}
