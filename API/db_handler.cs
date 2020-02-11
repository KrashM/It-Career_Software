using System.Data;
using System.Data.SqlClient;

namespace API.Handlers{

    public class Handler{

        public Handler(){

            Connect();

        }

        private void Connect(){

            string constr;
            SqlConnection conn;
            constr = @"Data Source=localhost;Initial Catalog=Main;User ID=root;Password=root";
            conn = new SqlConnection(constr);
            conn.Open();
            Console.WriteLine("Connection Open!");
            conn.Close();

        }

    }

}