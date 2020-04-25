using System;
using Software_Project.Business;

namespace Software_Project.Presentation{

    class DistributorBusinessMenu{

        public DistributorBusinessMenu(){
            Menu();
        }

        private void Menu(){

            PrintMenu();

            int input;

            while(true){

                Console.Write("Input: ");
                input = int.Parse(Console.ReadLine());
                Console.WriteLine();

                if(!(input < 1 || input > 6)) break;

                Console.WriteLine(new string('-', 28));
                Console.WriteLine("Please enter a valid number!");
                Console.WriteLine(new string('-', 28) + '\n');

            }

            switch(input){

                case 1:
                    CreateDistributor();
                    break;

                case 2:
                    GetInfo();
                    break;

                case 3:
                    CheckProduct();
                    break;

                case 4:
                    CreateProduct();
                    break;

                case 5:
                    RemoveProduct();
                    break;

                case 6:
                    return;

            }

        }

        private void PrintMenu(){

            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 10) + "DISTRIBUTOR BUSINESS");
            Console.WriteLine(new string('-', 40) + '\n');

            Console.WriteLine("1. Create distributor");
            Console.WriteLine("2. Get information");
            Console.WriteLine("3. Check for product");
            Console.WriteLine("4. Add new product");
            Console.WriteLine("5. Remove product");
            Console.WriteLine("6. Exit\n");

        }

        private void CreateDistributor(){

            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Address: ");
            string address = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Phone: ");
            string phone = Console.ReadLine();

            DistributorBusiness.CreateDistributor(name, address, email, phone);

        }

        private void GetInfo(){

            string name;

            Console.Clear();

            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 10) + "GET INFORMATION");
            Console.WriteLine(new string('-', 40));
            Console.WriteLine();

            while(true){

                Console.Write("Distributor name: ");
                name = Console.ReadLine();
                Console.WriteLine();

                if(DistributorBusiness.DistributorExists(DistributorBusiness.GetID(name))) break;
                
                Console.WriteLine(new string('-', 26));
                Console.WriteLine("Please enter a valid distributor name!");
                Console.WriteLine(new string('-', 26) + '\n');

            }

            Console.WriteLine(DistributorBusiness.GetInfo(DistributorBusiness.GetID(name)));
            Console.ReadKey();

        }

        private void CheckProduct(){

            string distributorName, productName;

            Console.Clear();

            Console.WriteLine(new string('-', 41));
            Console.WriteLine(new string(' ', 12) + "CHECK FOR PRODUCT");
            Console.WriteLine(new string('-', 41) + '\n');

            while(true){

                Console.Write("Distributor name: ");
                distributorName = Console.ReadLine();
                Console.WriteLine();

                if(DistributorBusiness.DistributorExists(DistributorBusiness.GetID(distributorName))) break;
                
                Console.WriteLine(new string('-', 26));
                Console.WriteLine("Please enter a valid distributor name!");
                Console.WriteLine(new string('-', 26) + '\n');

            }

            Console.Write("Product name: ");
            productName = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine(DistributorBusiness.CheckForProduct(DistributorBusiness.GetID(distributorName), ProductBusiness.GetID(productName)) ? $"Distributor {distributorName} provides product: {productName}" : $"Distributor {distributorName} does not provide product: {productName}");
            Console.ReadKey();

        }

        private void CreateProduct(){

            string productName, distributorName;
            decimal price;

            Console.Clear();

            Console.WriteLine(new string('-', 41));
            Console.WriteLine(new string(' ', 15) + "ADD PRODUCT");
            Console.WriteLine(new string('-', 41) + '\n');

            while(true){

                Console.Write("Distributor name: ");
                distributorName = Console.ReadLine();
                Console.WriteLine();

                if(DistributorBusiness.DistributorExists(DistributorBusiness.GetID(distributorName))) break;

                Console.WriteLine(new string('-', 26));
                Console.WriteLine("Please enter a valid distributor name!");
                Console.WriteLine(new string('-', 26) + '\n');

            }

            while(true){

                Console.Write("Product name: ");
                productName = Console.ReadLine();
                Console.WriteLine();

                if(!ProductBusiness.CheckForProduct(ProductBusiness.GetID(productName))) break;

                Console.WriteLine(new string('-', 26));
                Console.WriteLine("Please enter a valid name!");
                Console.WriteLine(new string('-', 26) + '\n');

            }

            while (true){

                Console.Write("Price for one product: ");
                price = decimal.Parse(Console.ReadLine());
                Console.WriteLine();

                if(!(price <= 0)) break;

                Console.WriteLine(new string('-', 27));
                Console.WriteLine("Please enter a valid price!");
                Console.WriteLine(new string('-', 27) + '\n');

            }

            ProductBusiness.AddProduct(DistributorBusiness.GetID(distributorName), productName, price);

        }

        private void RemoveProduct(){
            
            string distributorName, productName;

            Console.Clear();

            Console.WriteLine(new string('-', 41));
            Console.WriteLine(new string(' ', 15) + "ADD PRODUCT");
            Console.WriteLine(new string('-', 41) + '\n');

            while(true){

                Console.Write("Distributor name: ");
                distributorName = Console.ReadLine();
                Console.WriteLine();

                if(DistributorBusiness.DistributorExists(DistributorBusiness.GetID(distributorName))) break;
                
                Console.WriteLine(new string('-', 26));
                Console.WriteLine("Please enter a valid distributor name!");
                Console.WriteLine(new string('-', 26) + '\n');

            }

            while(true){

                Console.Write("Product name: ");
                productName = Console.ReadLine();
                Console.WriteLine();

                if(ProductBusiness.CheckForProduct(ProductBusiness.GetID(productName))) break;

                Console.WriteLine(new string('-', 26));
                Console.WriteLine("Please enter a valid name!");
                Console.WriteLine(new string('-', 26) + '\n');
                
            }
            
            DistributorBusiness.RemoveProduct(DistributorBusiness.GetID(distributorName), ProductBusiness.GetID(productName));

        }

    }

}
