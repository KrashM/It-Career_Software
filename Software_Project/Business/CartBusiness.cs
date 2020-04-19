using Software_Project.Data;
using Software_Project.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Software_Project.Business{

    class CartBusiness{

        private Context context;

        public void AddItem(int user_id, Product product){
            using (context = new Context()){
                context.Users.Find(user_id).Cart.Products.Add(product);
            }
        }

        public void RemoveItem(int user_id, Product product){
            using (context = new Context()){
                Product item = context.Users.Find(user_id).Cart.Products.Find(x => x.Id == product.Id);
                if(item == null) return;
                context.Users.Find(user_id).Cart.Products.Remove(item);
                context.SaveChanges();
            }
        }

        public List<Product> ListAllItemsInCart(int user_id){
            using (context = new Context()){
                return context.Users.Find(user_id).Cart.Products.ToList();
            }
        }

        public decimal GetTotalPrice(int user_id){
            using (context = new Context()){
                return context.Users.Find(user_id).Cart.Sum();
            }
        }

    }

}