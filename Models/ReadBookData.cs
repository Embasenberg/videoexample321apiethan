using System.Collections.ObjectModel;
using System.Collections.Generic;
using API.Models.Interfaces;
using MySql.Data.MySqlClient;

namespace API.Models
{
    public class ReadBookData : IGetAllBooks, IGetBook
    {
        public List<Book> GetAllBooks()
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"SELECT * FROM books";
            using var cmd = new MySqlCommand(stm, con);
            cmd.ExecuteNonQuery();

            using MySqlDataReader rdr = cmd.ExecuteReader();


            List<Book> allBooks = new List<Book>();
            while (rdr.Read())
            {
                allBooks.Add(new Book() { Id = rdr.GetInt32(0), Title = rdr.GetString(1), Author = rdr.GetString(2) });

            }

            return allBooks;


        }

        public Book GetBook(int id)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = "SELECT * FROM books WHERE id = @id";
            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
            cmd.Prepare();
            using MySqlDataReader rdr = cmd.ExecuteReader();

            rdr.Read();
            return new Book() { Id = rdr.GetInt32(0), Title = rdr.GetString(1), Author = rdr.GetString(2) };
        }
    }
}