using System.Linq;
using System.Collections.Generic;
using System;
using Software_Project.Data;
using Software_Project.Data.Models;
using Software_Project.Presentation;

namespace Software_Project.Business{

    static class CartBusiness{

        private static Context context;

        public static string ListAllItemsInCart(int userID){
            using (context = new Context()){
                return string.Join('\n', context.Carts.ToList().FindAll(x => x.UserID == userID));
            }
        }

        public static void AddItem(int userID, int productID, int amount){
            using (context = new Context()){
                Cart cart = new Cart();
                cart.ProductID = productID;
                cart.UserID = userID;
                cart.Amount = amount;
                context.Carts.Add(cart);
                context.SaveChanges();
            }
        }

        public static void RemoveItem(int userID, int productID){
            using (context = new Context()){
                Cart item = context.Carts.ToList().Find(x => (x.UserID == userID) && (x.ProductID == productID));
                if(item == null) return;
                context.Carts.Remove(item);
                context.SaveChanges();
            }
        }

        public static string GetTotalPrice(int userID){
            using (context = new Context()){
                Cart cart = context.Carts.ToList().Find(x => x.UserID == userID);
                List<(int, string, int, decimal)> products = context.Carts.ToList().FindAll(x => x.UserID == userID).Select(x => (x.ProductID, ProductBusiness.GetProduct(x.ProductID).Name, x.Amount, ProductBusiness.GetProduct(x.ProductID).Price)).ToList();
                string table = products.ToStringTable(new[] { "ID", "Product", "Amount", "Price      " }, p => p.Item1, p => p.Item2, p => p.Item3, p => p.Item4);
                table += $" |    |         | Total  | {products.Select(x => x.Item3 * x.Item4).Sum()}      | ";
                return table;
            }
        }

    }

}