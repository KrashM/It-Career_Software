using MySql.Data.MySqlClient;
using Software_Project.Hasher;

namespace Software_Project.Database_Handlers {

    class DB_Handler {

        private MySqlConnection conn = new MySqlConnection("Server=localhost;Uid=root;Pwd=root;");

        public DB_Handler() {

            Connect();

        }

        private void Connect() {

            conn.Open();
            MySqlCommand stm = new MySqlCommand("create database if not exists main; use main;", conn);
            stm.ExecuteScalar();
            Create_Tables();

        }

        private void Create_Tables(){

            MySqlCommand cmd = new MySqlCommand("create table if not exists users(username varchar(50), password varchar(100));", conn);
            cmd.ExecuteScalar();

        }

        private void Input(ref string username, ref string password){

            System.Console.WriteLine("Give me your username:");
            username = System.Console.ReadLine();
            System.Console.WriteLine("Give me your password:");
            password = System.Console.ReadLine();

        }

        public void Create_User(){

            string username = "", password = "";
            Input(ref username, ref password);
            
            var hash = Password_Hasher.Hash(password);
            var result = Password_Hasher.Verify(password, hash);

            //System.Console.WriteLine($"{username} => {hash}");

            MySqlCommand cmd = new MySqlCommand($"insert into users values('{username}', '{hash}');", conn);
            cmd.ExecuteScalar();

        }

        public void LogIn_User(){

            string username = "", password = "";
            Input(ref username, ref password);
            string hashed_pass = (string)new MySqlCommand($"select password from users where username = '{username}';", conn).ExecuteScalar();
            //System.Console.WriteLine($"{username} => {password} => {hashed_pass}");

            if(Password_Hasher.Verify(password, hashed_pass))
                System.Console.WriteLine("Successfully verified");
            else
                System.Console.WriteLine("Access denied");

        }
        
        public void Close_Connection(){

            conn.Close();

        }

    }

}
