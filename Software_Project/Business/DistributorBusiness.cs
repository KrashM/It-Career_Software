using System.Linq;
using Software_Project.Data;
using System.Collections.Generic;
using Software_Project.Data.Models;

namespace Software_Project.Business{

    static class DistributorBusiness{

        private static Context context;

        /// <summary>
        /// Finds a distributor with the specified name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns>The ID of the distributor found.</returns>
        public static int GetID(string name){
            using (context = new Context()){
                return context.Distributors.ToList().Find(x => x.Name == name).Id;
            }
        }

        /// <summary>
        /// Checks if a distributor exists in the system.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>True or false.</returns>
        public static bool DistributorExists(int id){
            using (context = new Context()){
                return context.Distributors.ToList().Find(x => x.Id == id) == null ? false : true;
            }
        }

        /// <summary>
        /// Make a new product in the distributor's list.
        /// </summary>
        /// <param name="distributorID"></param>
        /// <param name="productName"></param>
        /// <param name="price"></param>
        public static void CreateProduct(int distributorID, string productName, decimal price){
            using (context = new Context()){
                Product product = new Product();
                product.Name = productName;
                product.Price = price;
                product.DistributorID = distributorID;
                context.Products.Add(product);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Checks if a product is distributed by the specified distributor.
        /// </summary>
        /// <param name="distributorId"></param>
        /// <param name="productId"></param>
        /// <returns>True or false.</returns>
        public static bool CheckForProduct(int distributorId, int productId){
            using (context = new Context()){
                return context.Products.ToList().Any(x => (x.Id == productId) && (x.DistributorID == distributorId));
            }
        }

        /// <summary>
        /// Gets all information for the specified distributor.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>String table with all the contents.</returns>
        public static string GetInfo(int id){
            using (context = new Context()){
                Distributor thisDistributor = context.Distributors.ToList().Find(x => x.Id == id);
                List<(int, string, decimal)> products = DistributorBusiness.GetProducts(id).Select(x => (x.Id, x.Name, x.Price)).ToList();
                string table = products.ToStringTable(false, new[] { "ID", "Product", "Price" }, p => p.Item1, p => p.Item2, p => p.Item3);
                string info = $"Distributor: {thisDistributor.Name}\nAddress: {thisDistributor.Address}\nEmail: {thisDistributor.Email}\nPhone: {thisDistributor.Phone}\nProducts that they distribute:\n\n{table}";
                return info;
            }
        }

        /// <summary>
        /// Gets a specific product from the specified distributor.
        /// </summary>
        /// <param name="distributorID"></param>
        /// <param name="id"></param>
        /// <returns>The product found.</returns>
        public static Product GetProduct(int distributorID, int id){
            using (context = new Context()){
                return context.Products.ToList().Find(x => (x.Id == id) && (x.DistributorID == distributorID));
            }
        }

        /// <summary>
        /// Gets all the products wich the distributor offers.
        /// </summary>
        /// <param name="distributorID"></param>
        /// <returns>list with all the products.</returns>
        public static List<Product> GetProducts(int distributorID){
            using (context = new Context()){
                return context.Products.ToList().FindAll(x => x.DistributorID == distributorID);
            }
        }

        /// <summary>
        /// Makes a new distributor.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="address"></param>
        /// <param name="email"></param>
        /// <param name="phone"></param>
        public static void CreateDistributor(string name, string address, string email, string phone){
            using (context = new Context()) {
                Distributor distributor = new Distributor();
                distributor.Name = name;
                distributor.Address = address;
                distributor.Email = email;
                distributor.Phone = phone;
                context.Distributors.Add(distributor);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Removes a specified product from the list of the specified distributor.
        /// </summary>
        /// <param name="distributorID"></param>
        /// <param name="productID"></param>
        public static void RemoveProduct(int distributorID, int productID){
            using (context = new Context()){
                Product item = context.Products.ToList().Find(x => (x.Id == productID) && (x.DistributorID == distributorID));
                if(item == null) return;
                context.Products.Remove(item);
                context.SaveChanges();
            }
        }

    }

}