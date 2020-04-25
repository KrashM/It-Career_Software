using Software_Project.Data;
using Software_Project.Data.Models;
using System.Linq;

namespace Software_Project.Business{

    static class CartBusiness{

        private static Context context;

        public static string ListAllItemsInCart(int userID){
            using (context = new Context()){
                return string.Join('\n', context.Cart_Products.ToList().FindAll(x => x.UserID == userID));
            }
        }

        public static void AddItem(int userID, int productID, int amount){
            using (context = new Context()){
                Cart_Products cart_Products = new Cart_Products();
                cart_Products.UserID = userID;
                cart_Products.ProductID = productID;
                cart_Products.Amount = amount;
                context.Cart_Products.Add(cart_Products);
                context.SaveChanges();
            }
        }

        public static void RemoveItem(int userID, int productID){
            using (context = new Context()){
                Cart_Products item = context.Cart_Products.ToList().Find(x => (x.UserID == userID) && (x.ProductID == productID));
                if(item == null) return;
                context.Cart_Products.Remove(item);
                context.SaveChanges();
            }
        }

        public static decimal GetTotalPrice(int userID){
            using (context = new Context()){
                return context.Cart_Products.ToList().FindAll(x => x.UserID == userID).Select(x => x.Amount * ProductBusiness.GetProduct(x.ProductID).Price).Sum();
            }
        }

    }

}