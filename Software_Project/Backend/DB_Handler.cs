using MySql.Data.MySqlClient;
using Software_Project.Hasher;

namespace Software_Project.Database_Handlers {

    /// <summary>
    /// This class is responsible for the connection with the database and later for managing the data from it.
    /// </summary>
    class DB_Handler {

        //Connection string with the data for the local database.
        private MySqlConnection conn = new MySqlConnection("Server=localhost; Uid=root; Pwd=root;");

        //Constructor wich goes to connect the DB.
        public DB_Handler() {

            Connect();

        }

        /// <summary>
        /// Uses the connection string to connect to the local DB.
        /// </summary>
        private void Connect() {

            conn.Open();
            MySqlCommand stm = new MySqlCommand("create database if not exists main; use main;", conn);
            stm.ExecuteScalar();
            Create_Tables();

        }

        /// <summary>
        /// Creates the tables needed for the project.
        /// </summary>
        private void Create_Tables(){

            MySqlCommand cmd = new MySqlCommand("create table if not exists users(username varchar(50), password varchar(100));", conn);
            cmd.ExecuteScalar();

        }

        /// <summary>
        /// Input data for the user to register/log in.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        private void Input(ref string username, ref string password){

            System.Console.WriteLine("Give me your username:");
            username = System.Console.ReadLine();
            System.Console.WriteLine("Give me your password:");
            password = System.Console.ReadLine();

        }

        /// <summary>
        /// Register user.
        /// </summary>
        public void Create_User(){

            //Get the user's input data.
            string username = "", password = "";
            Input(ref username, ref password);
            
            //Hash the password and verify to make sure there is no error.
            var hash = Password_Hasher.Hash(password);
            if(!Password_Hasher.Verify(password, hash)){ return; }

            //Adds user to the DB.
            MySqlCommand cmd = new MySqlCommand($"insert into users values('{username}', '{hash}');", conn);
            cmd.ExecuteScalar();

        }

        /// <summary>
        /// Log in user.
        /// </summary>
        public void LogIn_User(){

            //Get the user's input data.
            string username = "", password = "";
            Input(ref username, ref password);

            //Get the user's hashed password.
            string hashed_pass = (string)new MySqlCommand($"select password from users where username = '{username}';", conn).ExecuteScalar();

            //Compare if the user has given the correct password.
            if(Password_Hasher.Verify(password, hashed_pass))
                System.Console.WriteLine("Successfully verified");
            else
                System.Console.WriteLine("Access denied");

        }
        
        /// <summary>
        /// Closes the connection when the program finishes.
        /// </summary>
        public void Close_Connection(){

            conn.Close();

        }

    }

}
