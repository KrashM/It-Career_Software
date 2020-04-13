using Software_Project.Database_Handlers;

namespace Software_Project {

    class Program {

        //Instances of the classes.
        private static DB_Handler handler;
        private static Program instance = new Program();

        /// <summary>
        /// This method returns a non static instance of the Program.
        /// </summary>
        /// <value>Program</value>
        public static Program Instance { get { return instance; } }

        //Main method
        static void Main() {

            handler = new DB_Handler();
            Instance.Initiate();
            handler.Close_Connection();

        }

        /// <summary>
        /// The user choses what to open from the menu.
        /// </summary>
        private void Initiate(){

            while(true){

                var selection = Menu();
                if(selection == 1)
                    Register();
                if(selection == 2)
                    LogIn();
                if(selection == 0)
                    break;

            }

        }

        /// <summary>
        /// Menu for register and log in.
        /// </summary>
        /// <returns>int</returns>
        private int Menu(){

            System.Console.WriteLine("1.Register\n2.Log in\n3.Exit");
            var input = int.Parse(System.Console.ReadLine());
            return (input == 1 || input == 2) ? input : 0;

        }

        /// <summary>
        /// Register the user.
        /// </summary>
        private void Register(){ handler.Create_User(); }

        /// <summary>
        /// Log in the user.
        /// </summary>
        private void LogIn(){ handler.LogIn_User(); }

    }

}
