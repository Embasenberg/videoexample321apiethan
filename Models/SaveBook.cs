using API.Models.Interfaces;
using MySql.Data.MySqlClient;

namespace API.Models
{
    public class SaveBook : IInsertBook
    {
        public void InsertBook(Book value)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"Insert INTO books(title,author) VALUES(@title, @author";
            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@title", value.Title);
            cmd.Parameters.AddWithValue("@author", value.Author);

            cmd.ExecuteNonQuery();
            cmd.Prepare();
            using MySqlDataReader rdr = cmd.ExecuteReader();

            //rdr.Read();

        }
    }
}