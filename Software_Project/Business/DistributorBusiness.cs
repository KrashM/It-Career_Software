using Software_Project.Data;
using Software_Project.Data.Models;

namespace Software_Project.Business{

    class DistributorBusiness{

        private Context context;

        public string GetInfo(int distributor_id){
            using (context = new Context()){
                return context.Distributors.Find(distributor_id).ToString();
            }
        }

        public bool CheckForProduct(int distributor_id, int product_id){
            using (context = new Context()){
                Product item = context.Distributors.Find(distributor_id).Products.Find(x => x.Id == product_id);
                if(item == null) return false;
                return true;
            }
        }

        public void AddProduct(int distributor_id, Product product){
            using (context = new Context()){
                context.Distributors.Find(distributor_id).Products.Add(product);
                context.SaveChanges();
            }
        }

        public void RemoveProduct(int distributor_id, int product_id){
            using (context = new Context()){
                Product item = context.Distributors.Find(distributor_id).Products.Find(x => x.Id == product_id);
                if(item == null) return;
                context.Distributors.Find(distributor_id).Products.Remove(item);
                context.SaveChanges();
            }
        }

    }

}