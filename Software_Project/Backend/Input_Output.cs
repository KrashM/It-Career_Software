namespace Software_Project{

    public static class IO{

        /// <summary>
        /// Input data for the user to register/log in.
        /// </summary>
        /// <param name="username">ref string</param>
        /// <param name="password">ref string</param>
        public static void Input(ref string username, ref string password){

            System.Console.WriteLine("Give me your username:");
            username = System.Console.ReadLine();
            System.Console.WriteLine("Give me your password:");
            password = System.Console.ReadLine();

        }

        /// <summary>
        /// Tell the user if the login is successful or not.
        /// </summary>
        /// <param name="flag">True=Success/False=Denied</param>
        public static void Output(bool flag=false){

            //Compare if the user has given the correct password.
            if(flag)
                System.Console.WriteLine("Successfully verified");
            else
                System.Console.WriteLine("Access denied");

        }

        /// <summary>
        /// Input money amount to change the balance with.
        /// </summary>
        /// <param name="amount">double</param>
        public static void Input_Money(ref double amount){

            System.Console.WriteLine("Give me the amount:");
            amount = double.Parse(System.Console.ReadLine());

        }

    }

}