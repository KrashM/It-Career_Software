using Software_Project.Database_Handlers;

namespace Software_Project {

    class Program {

        private static DB_Handler handler;

        private static Program instance = new Program();
        public static Program Instance { get { return instance; } }

        static void Main() {

            handler = new DB_Handler();
            Instance.Initiate();
            handler.Close_Connection();

        }

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

        private int Menu(){

            System.Console.WriteLine("1.Register\n2.Log in\n3.Exit");
            var input = int.Parse(System.Console.ReadLine());
            return (input == 1 && input == 2) ? input : 0;

        }

        private void Register(){ handler.Create_User(); }

        private void LogIn(){ handler.LogIn_User(); }

    }

}
