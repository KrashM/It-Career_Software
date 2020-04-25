using System;
using Software_Project.Business;
using Software_Project.Data.Models;

namespace Software_Project.Presentation{

    class OfficeBusinessMenu{

        public OfficeBusinessMenu(){
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

            switch (input){

                case 1:
                    CreateOffice();
                    break;

                case 2:
                    ViewAllProducts();
                    break;

                case 3:
                    ViewAllOfficesInCity();
                    break;

                case 4:
                    LoadProduct();
                    break;

                case 5:
                    ShipProduct();
                    break;

                case 6:
                    return;

            }

        }

        private void PrintMenu(){

            Console.WriteLine(new string('-', 41));
            Console.WriteLine(new string(' ', 13) + "OFFICE BUSINESS");
            Console.WriteLine(new string('-', 41) + '\n');

            Console.WriteLine("1. Create office");
            Console.WriteLine("2. View all available products");
            Console.WriteLine("3. View all offices in a given city");
            Console.WriteLine("4. Load a product in a given office");
            Console.WriteLine("5. Ship a product from one office to another");
            Console.WriteLine("6. Exit\n");

        }

        private void CreateOffice() {

            string name, city, address, phone;

            Console.Clear();

            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 14) + "Create Office");
            Console.WriteLine(new string('-', 40) + '\n');

            while(true){

                Console.Write("Office name: ");
                name = Console.ReadLine();
                Console.WriteLine();

                if(!OfficeBusiness.OfficeExists(name)) break;

                Console.WriteLine(new string('-', 26));
                Console.WriteLine("Please enter a valid office name!");
                Console.WriteLine(new string('-', 26) + '\n');

            }

            while(true){

                Console.Write("City: ");
                city = Console.ReadLine();
                Console.WriteLine();

                if(city.Length > 2) break;

                Console.WriteLine(new string('-', 26));
                Console.WriteLine("Please enter a valid city name!");
                Console.WriteLine(new string('-', 26) + '\n');

            }

            while(true){

                Console.Write("Address: ");
                address = Console.ReadLine();
                Console.WriteLine();

                if(address.Length > 6) break;

                Console.WriteLine(new string('-', 26));
                Console.WriteLine("Please enter a valid address!");
                Console.WriteLine(new string('-', 26) + '\n');

            }

            while(true){

                Console.Write("Phone: ");
                phone = Console.ReadLine();
                Console.WriteLine();

                if(phone.Length > 9) break;

                Console.WriteLine(new string('-', 26));
                Console.WriteLine("Please enter a valid phone number!");
                Console.WriteLine(new string('-', 26) + '\n');

            }

            OfficeBusiness.CreateOffice(name, city, address, phone);

        }

        private void ViewAllOffices(){

            foreach(Office office in OfficeBusiness.GetAllOffices()) Console.WriteLine($"{office.Name} - {office.City}");
            Console.ReadKey();

        }

        private void ViewAllOfficesInCity(){

            Console.Clear();

            Console.WriteLine(new string('-', 41));
            Console.WriteLine(new string(' ', 15) + "ALL OFFICES");
            Console.WriteLine(new string('-', 41) + '\n');

            string city;

            while(true){
            
                Console.Write("City: ");
                city = Console.ReadLine();
                Console.WriteLine();

                if(!(city.Length < 1) && OfficeBusiness.CityExists(city)) break;

                Console.WriteLine(new string('-', 26));
                Console.WriteLine("Please enter a valid city!");
                Console.WriteLine(new string('-', 26) + '\n');

            }

            foreach (Office office in OfficeBusiness.AllOfficesInACity(city))
                Console.WriteLine($"{office.Name} - {office.City}");
            Console.ReadKey();

        }

        private void ViewAllProducts(){

            Console.Clear();

            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 14) + "ALL PRODUCTS");
            Console.WriteLine(new string('-', 40) + '\n');

            string name;

            while(true){

                Console.Write("Office name: ");
                name = Console.ReadLine();
                Console.WriteLine();

                if(OfficeBusiness.OfficeExists(name)) break;

                Console.WriteLine(new string('-', 26));
                Console.WriteLine("Please enter a valid office name!");
                Console.WriteLine(new string('-', 26) + '\n');

            }

            foreach (Product product in OfficeBusiness.AllProductsAvailableInOffice(OfficeBusiness.GetID(name)))
                Console.WriteLine(product.ToString() + "\nStock: " + OfficeBusiness.GetStock(OfficeBusiness.GetID(name), product.Id));

            Console.ReadKey();
            
        }

        private void LoadProduct(){

            string officeName, distributorName, productName;
            int stock;

            Console.Clear();

            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 14) + "LOAD PRODUCT");
            Console.WriteLine(new string('-', 40) + '\n');

            while(true){

                Console.Write("Office name: ");
                officeName = Console.ReadLine();
                Console.WriteLine();

                if(OfficeBusiness.OfficeExists(officeName)) break;

                Console.WriteLine(new string('-', 26));
                Console.WriteLine("Please enter a valid office name!");
                Console.WriteLine(new string('-', 26) + '\n');

            }

            while(true){

                Console.Write("Distributor name: ");
                distributorName = Console.ReadLine();
                Console.WriteLine();

                if(!(distributorName.Length < 1) && DistributorBusiness.DistributorExists(DistributorBusiness.GetID(distributorName))) break;

                Console.WriteLine(new string('-', 26));
                Console.WriteLine("Please enter a valid name!");
                Console.WriteLine(new string('-', 26) + '\n');

            }

            while(true){

                Console.Write("Product name: ");
                productName = Console.ReadLine();
                Console.WriteLine();

                if(DistributorBusiness.CheckForProduct(DistributorBusiness.GetID(distributorName), ProductBusiness.GetID(productName))) break;

                Console.WriteLine(new string('-', 27));
                Console.WriteLine("Please enter a valid price!");
                Console.WriteLine(new string('-', 27) + '\n');

            }

            while(true){

                Console.Write("Stock: ");
                stock = int.Parse(Console.ReadLine());
                Console.WriteLine();

                if(!(stock < 0)) break;

                Console.WriteLine(new string('-', 27));
                Console.WriteLine("Please enter a valid stock!");
                Console.WriteLine(new string('-', 27) + '\n');

            }

            OfficeBusiness.LoadProduct(OfficeBusiness.GetID(officeName), DistributorBusiness.GetProduct(DistributorBusiness.GetID(distributorName), ProductBusiness.GetID(productName)), stock);

        }

        private void ShipProduct(){
            
            string officeNameFrom, officeNameTo, productName;

            Console.Clear();

            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 14) + "SHIP PRODUCT");
            Console.WriteLine(new string('-', 40));
            Console.WriteLine();

            while(true){

                Console.Write("Office name(from): ");
                officeNameFrom = Console.ReadLine();
                Console.WriteLine();

                if(OfficeBusiness.OfficeExists(officeNameFrom)) break;

                Console.WriteLine(new string('-', 26));
                Console.WriteLine("Please enter a valid office name!");
                Console.WriteLine(new string('-', 26) + '\n');

            }

            while(true){

                Console.Write("Office name(to): ");
                officeNameTo = Console.ReadLine();
                Console.WriteLine();

                if(OfficeBusiness.OfficeExists(officeNameTo)) break;

                Console.WriteLine(new string('-', 26));
                Console.WriteLine("Please enter a valid office name!");
                Console.WriteLine(new string('-', 26) + '\n');

            }

            while(true){

                Console.Write("Product name: ");
                productName = Console.ReadLine();
                Console.WriteLine();

                if(OfficeBusiness.ProductAvailable(OfficeBusiness.GetID(officeNameFrom), ProductBusiness.GetID(productName))) break;

                Console.WriteLine(new string('-', 27));
                Console.WriteLine("Please enter a valid price!");
                Console.WriteLine(new string('-', 27) + '\n');

            }

            OfficeBusiness.TransferProduct(OfficeBusiness.GetID(officeNameFrom), OfficeBusiness.GetID(officeNameTo), ProductBusiness.GetID(productName));

        }

    }

}
