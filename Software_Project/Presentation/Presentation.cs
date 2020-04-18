using Software_Project.Business;
using Software_Project.Data.Models;

namespace Software_Project.Presentation{

    class Display{

        UserBusiness userBusiness = new UserBusiness();

        private string username;

        public Display(){
            Register_LogIn();
            Input();
        }

        private void Register_LogIn(){

            int selection = 1;
            while(selection > 0 && selection < 3){

                RegLogMenu();
                selection = int.Parse(System.Console.ReadLine());
                System.Console.Clear();
                switch(selection){

                    case 1:
                        Register();
                        break;
                    case 2:
                        LogIn();
                        break;

                }

            }

        }

        private void RegLogMenu(){

            System.Console.WriteLine(new string('-', 40));
            System.Console.WriteLine(new string(' ', 18) + "MENU");
            System.Console.WriteLine(new string('-', 40));
            System.Console.WriteLine("1. Register user");
            System.Console.WriteLine("2. Log In user");

        }

        private void Register(){

            System.Console.Write("Username: ");
            username = System.Console.ReadLine();
            System.Console.Write("Password: ");
            string password = System.Console.ReadLine();
            string hashed_pass = Password_Hasher.Hash(password);

            if(!Password_Hasher.Verify(password, hashed_pass)) return;

            User user = new User();
            user.Username = username;
            user.Password = hashed_pass;

            userBusiness.Register(user);

        }

        private void LogIn(){

            string username = System.Console.ReadLine(), password = System.Console.ReadLine();
            if(Password_Hasher.Verify(password, userBusiness.GetAllUsers().Find(x => x.Username == username).Password)) return;
            System.Console.WriteLine("Logged In!");

        }

        private void Input(){
            
            int selection = 1;
            while(selection > 0 && selection < 6){

                Menu();
                selection = int.Parse(System.Console.ReadLine());
                System.Console.Clear();
                switch(selection){

                    case 1:
                        Money();
                        break;
                    case 2:
                        Add();
                        break;
                    case 3:
                        Update();
                        break;
                    case 4:
                        Fetch();
                        break;
                    case 5:
                        Delete();
                        break;

                }

            }

        }

        private void Menu(){

            System.Console.WriteLine(new string('-', 40));
            System.Console.WriteLine(new string(' ', 18) + "MENU");
            System.Console.WriteLine(new string('-', 40));
            System.Console.WriteLine("1. Modify balance");
            System.Console.WriteLine("2. Add new entry");
            System.Console.WriteLine("3. Update entry");
            System.Console.WriteLine("4. Fetch entry by ID");
            System.Console.WriteLine("5. Delete entry by ID");
            System.Console.WriteLine("6. Exit entry");

        }
        
        private void Money(){
            
            System.Console.WriteLine("1. Deposit");
            System.Console.WriteLine("2. Withdraw");
            int selection = int.Parse(System.Console.ReadLine());
            System.Console.Write("Amount: ");
            float amount = float.Parse(System.Console.ReadLine());

            User user = userBusiness.GetAllUsers().Find(x => x.Username == username);

            if(selection == 1)
                user.Balance += amount;
            if(selection == 2)
                user.Balance -= amount;

            userBusiness.UpdateMoney(user);

        }

        private void ListAll(){

        }

        private void Add(){

        }

        private void Update(){

        }

        private void Fetch(){

        }

        private void Delete(){
            
        }

    }

}