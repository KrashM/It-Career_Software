using System;
using System.Linq;
using Software_Project.Business;
using Software_Project.Data.Models;

namespace Software_Project.Presentation{

    class UserBusinessMenu{

        private string username;

        public UserBusinessMenu(string username){
            this.username = username;
            Menu();
        }

        private void Menu(){

            PrintMenu();

            while (true) {

                Console.Write("Input: ");
                int input = int.Parse(Console.ReadLine());
                Console.WriteLine();

                if(!(input < 1 || input > 3)){

                    switch (input){

                        case 1:
                            ManageBalance();
                            return;

                        case 2:
                            RemoveUser();
                            return;

                        case 3:
                            return;

                    }

                }

                Console.WriteLine(new string('-', 28));
                Console.WriteLine("Please enter a valid number!");
                Console.WriteLine(new string('-', 28));
                Console.WriteLine();

            }

        }

        private void PrintMenu(){

            Console.WriteLine(new string('-', 41));
            Console.WriteLine(new string(' ', 14) + "USER BUSINESS");
            Console.WriteLine(new string('-', 41));
            Console.WriteLine();

            Console.WriteLine("1. Manage balance");
            Console.WriteLine("2. Delete account");
            Console.WriteLine("3. Log out\n");

        }

        private void RegisterUser(){


            Console.Clear();

            Console.WriteLine("*** User's username has to be at least 4 characters long!\n");

            Console.WriteLine("*** User's password has to be at least 8 characters long");
            Console.WriteLine("    and it has to contain at least one upper case letter, lower case letter and a number!\n");

            Console.WriteLine(new string('-', 41));
            Console.WriteLine(new string(' ', 12) + "USER REGISTRATION");
            Console.WriteLine(new string('-', 41) + '\n');

            while (true){

                Console.Write("Username: ");
                username = Console.ReadLine();
                Console.WriteLine();

                if(username.Length >= 4 && !UserBusiness.CheckForUser(UserBusiness.GetID(username))) break;

                Console.WriteLine("The username you have entered does not meet the requirements or has already been taken!");
                Console.WriteLine("Please enter a new one!\n");


            }

            while(true){

                Console.Write("Password: ");
                string password = Console.ReadLine();
                Console.WriteLine();
                
                if(password.Length >= 8 || password.Any(Char.IsUpper) || password.Any(Char.IsLower) || password.Any(Char.IsDigit)){
                    
                    string hashed_password = Password_Hasher.Hash(password);
                    Password_Hasher.Verify(password, hashed_password);

                    UserBusiness.Register(username, hashed_password);
                    return;

                }

                Console.WriteLine("The password you have entered does not meet the requirements!");
                Console.WriteLine("Please enter a new one!\n");

            }
            
        }

        private void RemoveUser(){

            Console.Clear();

            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 14) + "USER REMOVAL");
            Console.WriteLine(new string('-', 40) + '\n');

            for(int i = 0; i < 4; i++){

                Console.Write("Password: ");
                string password = Console.ReadLine();
                Console.WriteLine();

                if(Password_Hasher.Verify(password, UserBusiness.GetUserPassword(UserBusiness.GetID(username)))){

                    UserBusiness.RemoveUser(UserBusiness.GetID(username));
                    return;

                }

                Console.WriteLine($"The password you have entered is incorrect\nTry again! {i + 1}/4\n");

            }

        }

        private void ManageBalance(){

            Console.Clear();

            Console.WriteLine("*** The amount you want to deposit or withdraw has to be greater than 1$!\n");

            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 13) + "MANAGE BALANCE");
            Console.WriteLine(new string('-', 40));
            Console.WriteLine();

            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw\n");

            while (true){
                
                Console.Write("Input: ");
                int input = int.Parse(Console.ReadLine());
                Console.WriteLine();

                if(!(input < 1 || input > 2)){

                    switch (input){

                        case 1:
                            ManageBalance_Deposit();
                            return;

                        case 2:
                            ManageBalance_Withdraw();
                            return;

                    }

                }

                Console.WriteLine(new string('-', 28));
                Console.WriteLine("Please enter a valid number!");
                Console.WriteLine(new string('-', 28));
                Console.WriteLine();

            }

        }

        private void ManageBalance_Deposit(){

            Console.Clear();

            Console.WriteLine("*** The amount you want to deposit has to be greater than 5$!\n");

            Console.WriteLine(new string('-', 41));
            Console.WriteLine(new string(' ', 7) + "MANAGE BALANCE ---> DEPOSIT");
            Console.WriteLine(new string('-', 41));
            Console.WriteLine();

            while (true){
                
                Console.Write("Deposit amount: ");
                decimal amount = decimal.Parse(Console.ReadLine());
                Console.WriteLine();

                if(!(amount < 5)){
                    
                    UserBusiness.UpdateMoney(UserBusiness.GetID(username), amount);
                    return;

                }

                Console.WriteLine("The amount you have entered does not meet the requirements!");
                Console.WriteLine("Please enter a new one!\n");


            }

        }

        private void ManageBalance_Withdraw(){

            Console.Clear();

            Console.WriteLine("*** The amount you want to withdraw has to be greater than 5$!\n");

            Console.WriteLine(new string('-', 41));
            Console.WriteLine(new string(' ', 7) + "MANAGE BALANCE ---> WITHDRAW");
            Console.WriteLine(new string('-', 41));
            Console.WriteLine();

            while (true){
                
                Console.Write("Withdraw amount: ");
                decimal amount = decimal.Parse(Console.ReadLine());
                Console.WriteLine();

                if(!(amount < 5)){

                    UserBusiness.UpdateMoney(UserBusiness.GetID(username), -amount);
                    return;

                }

                Console.WriteLine("The amount you have entered does not meet the requirements!");
                Console.WriteLine("Please enter a new one!\n");


            }

        }

    }

}
