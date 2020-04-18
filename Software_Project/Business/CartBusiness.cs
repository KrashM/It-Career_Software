using Software_Project.Data;
using Software_Project.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Software_Project.Business{

    class CartBusiness{

        private Context context;

        public void AddItem(Product product){
            using (context = new Context()){
                context.Products.Add(product);
            }
        }

        public void RemoveItem(Product product){
            using (context = new Context()){
                Product item = context.Products.Find(product);
                if(item == null) return;
                context.Products.Remove(item);
                context.SaveChanges();
            }
        }

        public List<Product> ListAllItemsInCart(){
            using (context = new Context()){
                return context.Products.ToList();
            }
        }

        public decimal SumOfPrices(){
            using (context = new Context()){
                decimal sum = 0;
                List<Product> items = context.Products.ToList();
                foreach(Product item in items)
                    sum += item.Price;
                return sum;
            }
            
        }

    }

}