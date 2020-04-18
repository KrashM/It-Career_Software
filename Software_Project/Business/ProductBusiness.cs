using Software_Project.Data;
using Software_Project.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Software_Project.Business{

    class ProductBusiness{

        private Context context;

        public List<Product> GetAllProducts(){
            using (context = new Context()){
                return context.Products.ToList();
            }
        }

        public Product GetProduct(int id){
            using (context = new Context()){
                return context.Products.Find(id);
            }
        }

        public void AddProduct(Product product){
            using (context = new Context()){
                context.Products.Add(product);
                context.SaveChanges();
            }
        }

        public void UpdateProduct(Product product){
            using (context = new Context()){
                Product item = context.Products.Find(product.Id);
                if(item == null) return;
                context.Entry(item).CurrentValues.SetValues(product);
                context.SaveChanges();
            }
        }

        public void DeleteProduct(int id){
            using (context = new Context()){
                Product item = context.Products.Find(id);
                if(item == null) return;
                context.Products.Remove(item);
                context.SaveChanges();
            }
        }

    }

}