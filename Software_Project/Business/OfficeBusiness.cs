using System.Linq;
using Software_Project.Data;
using System.Collections.Generic;
using Software_Project.Data.Models;

namespace Software_Project.Business{

    static class OfficeBusiness{

        private static Context context;

        /// <summary>
        /// Finds a office with the specified name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns>The ID of the office found.</returns>
        public static int GetID(string name){
            using (context = new Context()){
                return context.Offices.ToList().Find(x => x.Name == name).Id;
            }
        }

        /// <summary>
        /// Gets how much of a specified product is stocked in a given office.
        /// </summary>
        /// <param name="officeID"></param>
        /// <param name="productID"></param>
        /// <returns>The amount of the product in the office.</returns>
        public static int GetStock(int officeID, int productID){
            using (context = new Context()) {
                return context.Office_Products.ToList().Find(x => (x.OfficeID == officeID) && (x.ProductID == productID)).Stock;
            }
        }

        /// <summary>
        /// Checks if the office exists.
        /// </summary>
        /// <param name="name"></param>
        /// <returns>True or false.</returns>
        public static bool OfficeExists(string name){
            using (context = new Context()){
                return context.Offices.Any(x => x.Name == name); 
            }
        }

        /// <summary>
        /// Creates a new office.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="city"></param>
        /// <param name="address"></param>
        /// <param name="phone"></param>
        public static void CreateOffice(string name, string city, string address, string phone) { 
            using (context = new Context()) {
                Office office = new Office();
                office.Name = name;
                office.City = city;
                office.Address = address;
                office.Phone = phone;
                context.Offices.Add(office);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Checks if there are any offices in a specified city.
        /// </summary>
        /// <param name="city"></param>
        /// <returns>True or false.</returns>
        public static bool CityExists(string city){
            using (context = new Context()){
                return context.Offices.Any(x => x.City == city);
            }
        }

        /// <summary>
        /// Checks if a specific product is stocked in an office.
        /// </summary>
        /// <param name="officeID"></param>
        /// <param name="productID"></param>
        /// <returns>True or false.</returns>
        public static bool ProductAvailable(int officeID, int productID){
            using (context = new Context()){
                return context.Office_Products.Any(x => (x.OfficeID == officeID) && (x.ProductID == productID));
            }
        }

        /// <summary>
        /// Gets a list of all the offices.
        /// </summary>
        /// <returns>list of all the offices.</returns>
        public static List<Office> GetAllOffices(){
            using (context = new Context()){
                return context.Offices.ToList();
            }
        }

        /// <summary>
        /// Gets all available products in an office.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Table of all the products and their stock.</returns>
        public static string AllProductsAvailableInOffice(int id){
            using (context = new Context()){
                List<(int, string, decimal, int)> products = context.Office_Products.ToList().FindAll(x => x.OfficeID == id).Select(x => (x.ProductID, context.Products.ToList().Find(y => y.Id == x.ProductID).Name, context.Products.ToList().Find(y => y.Id == x.ProductID).Price, x.Stock)).ToList();
                string table = products.ToStringTable(false, new[] { "ID", "Product", "Price", "Stock" }, p => p.Item1, p => p.Item2, p => p.Item3, p => p.Item4);
                return table;
            }
        }

        /// <summary>
        /// Gets all offices in a specified city.
        /// </summary>
        /// <param name="city"></param>
        /// <returns>List of all the offices in that city.</returns>
        public static List<Office> AllOfficesInACity(string city){
            using (context = new Context()){
                List<Office> officesInThatCity = new List<Office>();
                foreach(Office office in context.Offices)
                    if(office.City == city)
                        officesInThatCity.Add(office);
                return officesInThatCity;
            }
        }

        /// <summary>
        /// Loads a product to an office.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="product"></param>
        /// <param name="stock"></param>
        public static void LoadProduct(int id, Product product, int stock){
            using  (context = new Context()){
                Office_Product office_Product = new Office_Product();
                office_Product.ProductID = product.Id;
                office_Product.OfficeID = id;
                office_Product.Stock = stock;
                context.Office_Products.Add(office_Product);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Transfers products from one office to another.
        /// </summary>
        /// <param name="oldOfficeID"></param>
        /// <param name="newOfficeID"></param>
        /// <param name="productID"></param>
        public static void TransferProduct(int oldOfficeID, int newOfficeID, int productID){
            using (context = new Context()){
                context.Office_Products.ToList().Find(x => (x.OfficeID == oldOfficeID) && (x.ProductID == productID)).OfficeID = newOfficeID;
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Ships products from the office.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="productID"></param>
        /// <param name="amount"></param>
        public static void ShipProduct(int id, int productID, int amount){
            using (context = new Context()){
                if(context.Office_Products.ToList().Find(x => (x.OfficeID == id) && (x.ProductID == productID)).Stock < amount) return;
                context.Office_Products.ToList().Find(x => (x.OfficeID == id) && (x.ProductID == productID)).Stock -= amount;
                context.SaveChanges();
            }
        }

    }

}