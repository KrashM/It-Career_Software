using Software_Project.Data;
using Software_Project.Data.Models;
using System.Linq;
using System.Collections.Generic;

namespace Software_Project.Business{

    static class DistributorBusiness{

        private static Context context;

        public static int GetID(string name){
            using (context = new Context()){
                return context.Distributors.ToList().Find(x => x.Name == name).Id;
            }
        }

        public static bool DistributorExists(int id){
            using (context = new Context()){
                return context.Distributors.ToList().Find(x => x.Id == id) == null ? false : true;
            }
        }

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

        public static bool CheckForProduct(int distributorId, int productId){
            using (context = new Context()){
                return context.Products.ToList().Any(x => (x.Id == productId) && (x.DistributorID == distributorId));
            }
        }

        public static string GetInfo(int id){
            using (context = new Context()){
                return context.Distributors.ToList().Find(x => x.Id == id).ToString();
            }
        }

        public static Product GetProduct(int distributorID, int id){
            using (context = new Context()){
                return context.Products.ToList().Find(x => (x.Id == id) && (x.DistributorID == distributorID));
            }
        }

        public static List<Product> GetProducts(int distributorID){
            using (context = new Context()){
                return context.Products.ToList().FindAll(x => x.DistributorID == distributorID);
            }
        }

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