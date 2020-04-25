using System;
using Software_Project.Business;

namespace Software_Project.Presentation{

    class CartBusinessMenu{

        private string username;

        public CartBusinessMenu(string username){
            this.username = username;
            Menu();
        }

        private void Menu(){

            PrintMenu();

            while (true){
                
                Console.Write("Input: ");
                int input = int.Parse(Console.ReadLine());
                Console.WriteLine();

                if(input > 0 || input < 6){

                    switch (input){

                        case 1:
                            ListAllItemsInCart();
                            
                            return;

                        case 2:
                            AddItem();
                            return;

                        case 3:
                            RemoveItem();
                            return;

                        case 4:
                            GetPriceTotal();
                            return;

                        case 5:
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

            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 14) + "CART BUSINESS");
            Console.WriteLine(new string('-', 40));
            Console.WriteLine();

            Console.WriteLine("1. List all items in cart");
            Console.WriteLine("2. Add item");
            Console.WriteLine("3. Remove item");
            Console.WriteLine("4. Get price total");
            Console.WriteLine("5. Exit\n");

        }

        private void ListAllItemsInCart(){

            Console.Clear();

            Console.WriteLine(new string('-', 41));
            Console.WriteLine(new string(' ', 13) + "LIST ALL ITEMS");
            Console.WriteLine(new string('-', 41) + '\n');

            Console.WriteLine(CartBusiness.ListAllItemsInCart(UserBusiness.GetID(username)) + '\n');
            Console.ReadKey();

        }

        private void AddItem(){

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


        private void GetPriceTotal(){

            Console.Clear();

            Console.WriteLine(new string('-', 41));
            Console.WriteLine(new string(' ', 13) + "GET PRICE TOTAL");
            Console.WriteLine(new string('-', 41) + '\n');

            Console.WriteLine(CartBusiness.GetTotalPrice(UserBusiness.GetID(username)) + '\n');
            Console.ReadKey();

        }

    }

}
