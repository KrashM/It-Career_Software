using MySql.Data.MySqlClient;
using MySql.Data;

namespace Software_Project.Handlers {

    class Handler {

        public Handler() {

            Connect();

        }

        private void Connect() {

            MySqlConnection conn = new MySqlConnection("Server=localhost;Database=main;Uid=root;Pwd=root;");
            conn.Open();
            System.Console.WriteLine("Connection Open!");
            var stm = "use main;create table users(username varchar(50));insert into users values('Hristo'),('Pesho');";
            var cmd = new MySqlCommand(stm, conn);
            cmd.ExecuteScalar();
            stm = "select * from users;";
            cmd = new MySqlCommand(stm, conn);
            var result = cmd.ExecuteScalar().ToString();
            System.Console.WriteLine($"{result}");
            conn.Close();

        }
    }
}
