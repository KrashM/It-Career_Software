using Software_Project.Data;
using Software_Project.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Software_Project.Business{

    class ProductBusiness{

        private Context context;

        public List<Product> GetAllProducts(int office_id){
            using (context = new Context()){
                return context.Offices.Find(office_id).ProductsAvailable.ToList();
            }
        }

        public Product GetProduct(int office_id, int id){
            using (context = new Context()){
                return context.Offices.Find(office_id).ProductsAvailable.Find(x => x.Id == id);
            }
        }

        public void AddProduct(int office_id, Product product){
            using (context = new Context()){
                context.Offices.Find(office_id).ProductsAvailable.Add(product);
                context.SaveChanges();
            }
        }

        public void UpdateProduct(int office_id, Product product){
            using (context = new Context()){
                Product item = context.Offices.Find(office_id).ProductsAvailable.Find(x => x.Id == product.Id);
                if(item == null) return;
                context.Entry(item).CurrentValues.SetValues(product);
                context.SaveChanges();
            }
        }

        public void RemoveProduct(int office_id, int id){
            using (context = new Context()){
                Product item = context.Offices.Find(office_id).ProductsAvailable.Find(x => x.Id == id);
                if(item == null) return;
                context.Offices.Find(office_id).ProductsAvailable.Remove(item);
                context.SaveChanges();
            }
        }

    }

}