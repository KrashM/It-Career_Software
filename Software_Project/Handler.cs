using System.Data.SqlClient;

namespace Software_Project.Handlers {

    class Handler {

        public Handler() {

            Connect();

        }

        private void Connect() {

            string constr;
            SqlConnection conn;
            constr = @"Data Source=localhost;Initial Catalog=Main;User ID=root;Password=root";
            conn = new SqlConnection(constr);
            conn.Open();
            System.Console.WriteLine("Connection Open!");
            conn.Close();

        }
    }
}
