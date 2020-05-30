using System.Linq;
using Software_Project.Data;
using System.Collections.Generic;
using Software_Project.Data.Models;

namespace Software_Project.Business{

    static class ProductBusiness{

        private static Context context;

        /// <summary>
        /// Gets the ID of a specified product.
        /// </summary>
        /// <param name="name"></param>
        /// <returns>The ID of the product.</returns>
        public static int GetID(string name){
            using (context = new Context()){
                Product item = context.Products.ToList().Find(x => x.Name == name);
                if (item == null) return -1;
                return item.Id;
            }
        }

        /// <summary>
        /// Checks if a product exists.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>True or false.</returns>
        public static bool CheckForProduct(int id){
            using (context = new Context()){
                return context.Products.ToList().Any(x => x.Id == id);
            }
        }

        /// <summary>
        /// Gets all products in the system.
        /// </summary>
        /// <returns>Table of all the products in the system.</returns>
        public static string GetAllProducts(){
            using (context = new Context()){
                List<(int, string, decimal, string)> products = context.Products.ToList().Select(x => (x.Id, x.Name, x.Price, context.Distributors.ToList().Find(y => y.Id == x.DistributorID).Name)).ToList();
                string table = products.ToStringTable(false, new[] { "ID", "Product", "Price", "Distributor" }, p => p.Item1, p => p.Item2, p => p.Item3, p => p.Item4);
                return table;
            }
        }

        /// <summary>
        /// Gets a product from the system to be used.
        /// </summary>
        /// <param name="productID"></param>
        /// <returns>The product found.</returns>
        public static Product GetProduct(int productID){
            using (context = new Context()){
                return context.Products.ToList().Find(x => x.Id == productID);
            }
        }

        /// <summary>
        /// Adds a new product to the system.
        /// </summary>
        /// <param name="distributorID"></param>
        /// <param name="name"></param>
        /// <param name="price"></param>
        public static void AddProduct(int distributorID, string name, decimal price){
            using (context = new Context()){
                Product product = new Product();
                product.Name = name;
                product.Price = price;
                product.DistributorID = distributorID;
                context.Products.Add(product);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Updates the name of a product.
        /// </summary>
        /// <param name="oldName"></param>
        /// <param name="newName"></param>
        public static void UpdateName(string oldName, string newName){
            using (context = new Context()){
                Product item = context.Products.ToList().Find(x => x.Name == oldName);
                if(item == null) return;
                Product newProduct = item;
                newProduct.Name = newName;
                context.Entry(item).CurrentValues.SetValues(newProduct);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Updates the price of a product.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="price"></param>
        public static void UpdatePrice(string name, decimal price){
            using (context = new Context()){
                Product item = context.Products.ToList().Find(x => x.Name == name);
                if(item == null) return;
                Product newProduct = item;
                newProduct.Price = price;
                context.Entry(item).CurrentValues.SetValues(newProduct);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Updates the whole product.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="product"></param>
        public static void UpdateProduct(string name, Product product){
            using (context = new Context()){
                Product item = context.Products.ToList().Find(x => x.Name == name);
                if(item == null) return;
                context.Entry(item).CurrentValues.SetValues(product);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Removes a specific product from the system.
        /// </summary>
        /// <param name="productID"></param>
        public static void RemoveProduct(int productID){
            using (context = new Context()){
                Product item = context.Products.ToList().Find(x => x.Id == productID);
                if(item == null) return;
                context.Products.Remove(item);
                context.Office_Products.ToList().RemoveAll(x => x.ProductID == productID);
                context.SaveChanges();
            }
        }

    }

}