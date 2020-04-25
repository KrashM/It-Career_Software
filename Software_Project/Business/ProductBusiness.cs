using Software_Project.Data;
using Software_Project.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Software_Project.Business{

    static class ProductBusiness{

        private static Context context;

        public static int GetID(string name){
            using (context = new Context()){
                Product item = context.Products.ToList().Find(x => x.Name == name);
                if (item == null) return -1;
                return item.Id;
            }
        }

        public static bool CheckForProduct(int id){
            using (context = new Context()){
                return context.Products.ToList().Any(x => x.Id == id);
            }
        }

        public static string GetAllProducts(){
            using (context = new Context()){
                return string.Join('\n', context.Products.Select(x => x.Name));
            }
        }

        public static List<Product> GetAllProductsFromDistrubor(int distributorID){
            using (context = new Context()) {
                return context.Products.ToList().FindAll(x => x.DistributorID == distributorID);
            }
        }

        public static Product GetProduct(int productID){
            using (context = new Context()){
                return context.Products.ToList().Find(x => x.Id == productID);
            }
        }

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
        public static void UpdateProduct(string name, Product product){
            using (context = new Context()){
                Product item = context.Products.ToList().Find(x => x.Name == name);
                if(item == null) return;
                context.Entry(item).CurrentValues.SetValues(product);
                context.SaveChanges();
            }
        }

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