using System;
using Software_Project.Business;

namespace Software_Project.Presentation{

    class Display{

        private string username;

        public Display(){
            Register_LogIn();
            Input();
        }

        private void Register_LogIn(){

            int selection;

            while(true){

                RegLogMenu();
                selection = int.Parse(Console.ReadLine());
                Console.Clear();

                if(!(selection < 1 || selection > 2)) break;

            }

            switch(selection){

                    case 1:
                        Register();
                        break;
                    case 2:
                        LogIn();
                        break;

            }

        }

        private void RegLogMenu(){

            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 18) + "MENU");
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. Register user");
            Console.WriteLine("2. Log In user");

        }

        private void Register(){

            Console.Write("Username: ");
            username = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();
            string hashed_pass = Password_Hasher.Hash(password);

            if(!Password_Hasher.Verify(password, hashed_pass)) return;

            UserBusiness.Register(username, hashed_pass);

        }

        private void LogIn(){

            //CAN LOG IN WITH ANY PASSWORD OR WITHOUT ONE
            Console.Write("Username: ");
            username = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();
            if (Password_Hasher.Verify(password, UserBusiness.GetUser(UserBusiness.GetID(username)).Password)) return;
            Console.WriteLine("Logged In!");

        }

        private void Input(){

            int selection;

            while(true){

                Console.Clear();
                Menu();
                selection = int.Parse(Console.ReadLine());
                Console.Clear();

                if((selection < 1 || selection > 5)) break;

                switch(selection){

                    case 1:
                        UserBusinessMenu userMenu = new UserBusinessMenu(username);
                        break;
                    case 2:
                        CartBusinessMenu cartMenu = new CartBusinessMenu(username);
                        break;
                    case 3:
                        ProductBusinessMenu productMenu = new ProductBusinessMenu();
                        break;
                    case 4:
                        OfficeBusinessMenu officeMenu = new OfficeBusinessMenu();
                        break;
                    case 5:
                        DistributorBusinessMenu distributorMenu = new DistributorBusinessMenu();
                        break;

                }

            }

        }

        private void Menu(){

            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 18) + "MENU");
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. User menu");
            Console.WriteLine("2. Cart menu");
            Console.WriteLine("3. Product menu");
            Console.WriteLine("4. Office menu");
            Console.WriteLine("5. Distributor menu");
            Console.WriteLine("6. Exit entry\n");

        }

    }

}