using MySql.Data.MySqlClient;
using Software_Project.Hasher;

namespace Software_Project.Database_Handlers {

    /// <summary>
    /// This class is responsible for the connection with the database and later for managing the data from it.
    /// </summary>
    class DB_Handler {

        //Connection string with the data for the local database.
        private MySqlConnection conn = new MySqlConnection("Server=localhost; Uid=root; Pwd=root;");
        //User's data.
        private string username, password;

        //Constructor wich goes to connect the DB.
        public DB_Handler() {

            Connect();

        }

        /// <summary>
        /// Uses the connection string to connect to the local DB.
        /// </summary>
        private void Connect() {

            conn.Open();
            new MySqlCommand("create database if not exists main; use main;", conn).ExecuteScalar();
            Create_Tables();

        }

        /// <summary>
        /// Creates the tables needed for the project.
        /// </summary>
        private void Create_Tables(){

            //Users table.
            new MySqlCommand("create table if not exists users(username varchar(50), password varchar(100), balance double);", conn).ExecuteScalar();

        }
        
        /// <summary>
        /// Register user.
        /// </summary>
        public void Create_User(){

            //Get the user's input data.
            IO.Input(ref username, ref password);

            //Check if username already exists.
            MySqlCommand user_exists = new MySqlCommand($"select username from users where username='{username}';", conn);
            if(user_exists.ExecuteScalar() != null) {
                IO.Output(false);
                return;
            }
            
            //Hash the password and verify to make sure there is no error.
            var hash = Password_Hasher.Hash(password);
            if(!Password_Hasher.Verify(password, hash)){ return; }

            //Adds user to the DB.
            new MySqlCommand($"insert into users values('{username}', '{hash}', 0);", conn).ExecuteScalar();

        }

        /// <summary>
        /// Log in user.
        /// </summary>
        public void LogIn_User(){

            //Get the user's input data.
            IO.Input(ref username, ref password);

            //Get the user's hashed password.
            string hashed_pass = (string)new MySqlCommand($"select password from users where username = '{username}';", conn).ExecuteScalar();

            //Check if the user exists.
            if(hashed_pass == null){
                System.Console.WriteLine("Wrong/Not existing user!");
                return;
            }

            //Determine if the user has entered the right password or not.
            if(Password_Hasher.Verify(password, hashed_pass))
                IO.Output(true);
            else
                IO.Output(false);

        }

        /// <summary>
        /// Change the balance of the user.True is for depositing and false is for withdrawing.
        /// </summary>
        /// <param name="flag">True=depositing/false=withdrawing.</param>
        public void Money(bool flag){

            //Get the users balance and an amount to modify it with.
            double amount = 0, balance;
            balance = (double)new MySqlCommand($"select balance from users where username='{username}';", conn).ExecuteScalar();
            IO.Input_Money(ref amount);

            //Use the flag to either deposit or withdraw.
            if(flag)
                Deposit(ref balance, amount);
            else
                Withdraw(ref balance, amount);

            //Update the data in the database.
            new MySqlCommand($"update users set balance='{balance}' where username='{username}';", conn).ExecuteScalar();

        }

        /// <summary>
        /// Deposit a given amount to the balance.
        /// </summary>
        /// <param name="balance">ref double</param>
        /// <param name="amount">double</param>
        private static void Deposit(ref double balance, double amount){
            balance += amount;
        } 

        /// <summary>
        /// Withdraw a given amount from the balance.
        /// </summary>
        /// <param name="balance">ref double</param>
        /// <param name="amount">double</param>
        private static void Withdraw(ref double balance, double amount){
            balance -= amount;
        } 
        
        /// <summary>
        /// Closes the connection when the program finishes.
        /// </summary>
        public void Close_Connection(){

            conn.Close();

        }

    }

}
