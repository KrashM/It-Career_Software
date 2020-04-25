using System;
using Software_Project.Data.Models;
using Software_Project.Business;

namespace Software_Project.Presentation{

    class ProductBusinessMenu{
    
        public ProductBusinessMenu(){
            Menu();
        }

        private void Menu(){

            PrintMenu();

            while (true) {

                Console.Write("Input: ");
                int input = int.Parse(Console.ReadLine());
                Console.WriteLine();

                if(!(input < 1 || input > 6)){

                    switch (input) {

                        case 1:
                            ViewAllProducts();
                            return;

                        case 2:
                            ViewSpecificProduct();
                            return;

                        case 3:
                            UpdateProduct();
                            return;

                        case 4:
                            RemoveProduct();
                            return;

                        case 5:
                            return;

                    }

                }

                Console.WriteLine(new string('-', 28));
                Console.WriteLine("Please enter a valid number!");
                Console.WriteLine(new string('-', 28) + '\n');

            }

        }

        private void PrintMenu(){

            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 12) + "PRODUCT BUSINESS");
            Console.WriteLine(new string('-', 40) + '\n');

            Console.WriteLine("1. View all products");
            Console.WriteLine("2. View specific product");
            Console.WriteLine("3. Update product");
            Console.WriteLine("4. Remove product");
            Console.WriteLine("5. Exit\n");

        }

        private void ViewAllProducts(){

            Console.Clear();

            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 14) + "ALL PRODUCTS");
            Console.WriteLine(new string('-', 40));
            Console.WriteLine();

            Console.WriteLine(ProductBusiness.GetAllProducts());
            Console.ReadKey();

        }

        private void ViewSpecificProduct() {

            Console.Clear();

            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 12) + "SPECIFIC PRODUCT");
            Console.WriteLine(new string('-', 40));
            Console.WriteLine();

            Console.Write("Product name: ");
            string productName = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine(ProductBusiness.GetProduct(ProductBusiness.GetID(productName)).ToString());
            Console.ReadKey();

        }

        private void UpdateProduct(){

            Console.Clear();

            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 13) + "UPDATE PRODUCT");
            Console.WriteLine(new string('-', 40) + '\n');

            Console.Write("Product name: ");
            string name = Console.ReadLine();
            Console.WriteLine();

            PrintUpdateProduct();

            while (true) {

                Console.Write("Input: ");
                int input = int.Parse(Console.ReadLine());
                Console.WriteLine();

                if(!(input < 1 || input > 3)){

                    switch (input) {
                        case 1:
                            UpdateName(name);
                            break;

                        case 2:
                            UpdatePrice(name);
                            break;

                        case 3:
                            UpdateAllFields(name);
                            break;

                    }
                    break;

                }

                Console.WriteLine(new string('-', 28));
                Console.WriteLine("Please enter a valid number!");
                Console.WriteLine(new string('-', 28) + '\n');

            }

        }

        private void PrintUpdateProduct(){

            Console.WriteLine("Update: \n");
            Console.WriteLine("1. Name");
            Console.WriteLine("2. Price");
            Console.WriteLine("3. All\n");

        }

        private void UpdateName(string name){

            while (true){

                Console.Write("New product name: ");
                string newName = Console.ReadLine();
                Console.WriteLine();

                if(!(name.Length < 1)) {
                    
                    ProductBusiness.UpdateName(name, newName);
                    break;
                
                }

                Console.WriteLine(new string('-', 26));
                Console.WriteLine("Please enter a valid name!");
                Console.WriteLine(new string('-', 26));
                Console.WriteLine();

            }


        }

        private void UpdatePrice(string name){

            while(true){

                Console.Write("New price for one product: ");
                decimal price = decimal.Parse(Console.ReadLine());
                Console.WriteLine();

                if(!(price <= 0)){

                    ProductBusiness.UpdatePrice(name, price);
                    break;

                }

                Console.WriteLine(new string('-', 27));
                Console.WriteLine("Please enter a valid price!");
                Console.WriteLine(new string('-', 27)+ '\n');

            }

        }

        private void UpdateAllFields(string name){

            string newName;
            decimal price;
            int stock;

            while(true){
                
                Console.Write("New product name: ");
                newName = Console.ReadLine();
                Console.WriteLine();

                if(!(name.Length < 1)) break;

                Console.WriteLine(new string('-', 26));
                Console.WriteLine("Please enter a valid name!");
                Console.WriteLine(new string('-', 26));
                Console.WriteLine();

            }


            while(true){

                Console.Write("New price for one product: ");
                price = decimal.Parse(Console.ReadLine());
                Console.WriteLine();

                if(!(price <= 0)) break;

                Console.WriteLine(new string('-', 27));
                Console.WriteLine("Please enter a valid price!");
                Console.WriteLine(new string('-', 27));
                Console.WriteLine();

            }


            while(true){
           
                Console.Write("New stock: ");
                stock = int.Parse(Console.ReadLine());
                Console.WriteLine();

                if(!(stock < 0)) break;

                Console.WriteLine(new string('-', 27));
                Console.WriteLine("Please enter a valid stock!");
                Console.WriteLine(new string('-', 27));
                Console.WriteLine();

            }

            Product product = new Product();
            product.Name = newName;
            product.Price = price;

            ProductBusiness.UpdateProduct(name, product);

        }

        private void RemoveProduct() {

            Console.Clear();

            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 13) + "DELETE PRODUCT");
            Console.WriteLine(new string('-', 40) + '\n');

            Console.Write("Product name: ");
            string productName = Console.ReadLine();
            Console.WriteLine();

            ProductBusiness.RemoveProduct(ProductBusiness.GetID(productName));

        }

    }

}
