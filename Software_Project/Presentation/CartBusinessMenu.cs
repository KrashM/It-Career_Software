using System;
using Software_Project.Business;

namespace Software_Project.Presentation{

    class CartBusinessMenu{

        private string username;

        /// <summary>
        /// Constructor. Sets the username to the curent user who is loged in.
        /// </summary>
        /// <param name="username"></param>
        public CartBusinessMenu(string username){
            this.username = username;
            Menu();
        }

        /// <summary>
        /// Functionality of the menu.
        /// </summary>
        private void Menu(){

            PrintMenu();
            int input;

            while (true){
                
                Console.Write("Input: ");
                input = int.Parse(Console.ReadLine());
                Console.WriteLine();

                if(input > 0 || input < 5) break;

                Console.WriteLine(new string('-', 28));
                Console.WriteLine("Please enter a valid number!");
                Console.WriteLine(new string('-', 28));
                Console.WriteLine();

            }

            

            switch (input){

                case 1:
                    ListAllItemsInCart();
                    break;

                case 2:
                    AddItem();
                    break;

                case 3:
                    RemoveItem();
                    break;

                case 4:
                    break;

            }

        }

        /// <summary>
        /// Printing the menu.
        /// </summary>
        private void PrintMenu(){

            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 14) + "CART BUSINESS");
            Console.WriteLine(new string('-', 40));
            Console.WriteLine();

            Console.WriteLine("1. List all items in cart");
            Console.WriteLine("2. Add item");
            Console.WriteLine("3. Remove item");
            Console.WriteLine("4. Exit\n");

        }

        /// <summary>
        /// Request a list of all the products in the cart and prints them.
        /// </summary>
        private void ListAllItemsInCart(){

            Console.Clear();

            Console.WriteLine(new string('-', 41));
            Console.WriteLine(new string(' ', 13) + "GET PRICE TOTAL");
            Console.WriteLine(new string('-', 41) + '\n');

            Console.WriteLine(CartBusiness.ListAllItemsInCart(UserBusiness.GetID(username)) + '\n');
            Console.ReadKey();

        }

        /// <summary>
        /// Prints all available products in the system and makes the user chose which one he wants to add to his cart. 
        /// </summary>
        private void AddItem(){

            Console.Clear();

            Console.WriteLine(ProductBusiness.GetAllProducts());

            Console.ReadKey();
            Console.Clear();

            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 16) + "ADD ITEM");
            Console.WriteLine(new string('-', 40) + '\n');

            string name;

            while (true){

                Console.Write("Product name: ");
                name = Console.ReadLine();
                Console.WriteLine();

                if(ProductBusiness.CheckForProduct(ProductBusiness.GetID(name))) break;

                Console.WriteLine(new string('-', 26));
                Console.WriteLine("Please enter a valid name!");
                Console.WriteLine(new string('-', 26) + '\n');

            }

            Console.Write("Amount of this product: ");
            int amount = int.Parse(Console.ReadLine());
            
            CartBusiness.AddItem(UserBusiness.GetID(username), ProductBusiness.GetID(name), amount);

        }

        /// <summary>
        /// Request to remove a product from the cart of the user.
        /// </summary>
        private void RemoveItem(){

            Console.Clear();

            Console.WriteLine(new string('-', 41));
            Console.WriteLine(new string(' ', 15) + "REMOVE ITEM");
            Console.WriteLine(new string('-', 41) + '\n');

            Console.Write("Product Name: ");
            string productName = Console.ReadLine();
            Console.WriteLine();

            CartBusiness.RemoveItem(UserBusiness.GetID(username), ProductBusiness.GetID(productName));

        }


    }

}
