namespace API.Models
{
    public class ConnectionString
    {
        public string cs { get; set; }

        public ConnectionString()
        {
            string server = "grp6m5lz95d9exiz.cbetxkdyhwsb.us-east-1.rds.amazonaws.com";
            string database = "yn37rjuhqxvn7rjw";
            string port = "3306";
            string userName = "mfjgldpja5pt3dzd";
            string password = "gd9f1mk3jh1uxcnm";



            cs = $@"server={server};user={userName};database={database};port={port};password={password};";
        }
    }
}