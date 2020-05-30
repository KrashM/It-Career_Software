using System.Linq;
using Software_Project.Data;
using System.Collections.Generic;
using Software_Project.Data.Models;

namespace Software_Project.Business{

    static class CartBusiness{

        private static Context context;

        /// <summary>
        /// Adds an amount of a product to a user's cart.
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="productID"></param>
        /// <param name="amount"></param>
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

        /// <summary>
        /// Removes a product with matching ID from a user's cart.
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="productID"></param>
        public static void RemoveItem(int userID, int productID){
            using (context = new Context()){
                Cart item = context.Carts.ToList().Find(x => (x.UserID == userID) && (x.ProductID == productID));
                if(item == null) return;
                context.Carts.Remove(item);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Gives a list of all the products in a user's cart.
        /// </summary>
        /// <param name="userID"></param>
        /// <returns>Table of all the products.</returns>
        public static string ListAllItemsInCart(int userID){
            using (context = new Context()){
                Cart cart = context.Carts.ToList().Find(x => x.UserID == userID);
                List<(string, string, string, string)> products = context.Carts.ToList().FindAll(x => x.UserID == userID).Select(x => (x.ProductID.ToString(), ProductBusiness.GetProduct(x.ProductID).Name, x.Amount.ToString(), ProductBusiness.GetProduct(x.ProductID).Price.ToString())).ToList();
                products.Add(("", "", "Total", products.Select(x => int.Parse(x.Item3) * decimal.Parse(x.Item4)).Sum().ToString()));
                string table = products.ToStringTable(true, new[] { "ID", "Product", "Amount", "Price" }, p => p.Item1, p => p.Item2, p => p.Item3, p => p.Item4);
                return table;
            }
        }

    }

}