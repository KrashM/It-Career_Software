using Software_Project.Data;
using Software_Project.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Software_Project.Business{

    class OfficeBusiness{

        private Context context;

        public List<Product> AllProductsAvailableInOffice(int office_id){
            using (context = new Context()){
                return context.Offices.Find(office_id).ProductsAvailable.ToList();
            }
        }

        public List<Distributor> DistributorsWhichLoadTheOffice(int office_id){
            using (context = new Context()){
                return context.Offices.Find(office_id).DistributorsLoadingTheOffice.ToList();
            }
        }

        public List<Office> AllOfficesInACity(string city){
            using (context = new Context()){
                List<Office> officesInThatCity = new List<Office>();
                foreach(Office office in context.Offices)
                    if(office.City == city)
                        officesInThatCity.Add(office);
                return officesInThatCity;
            }
        }

        public void LoadProduct(int office_id, Product product){
            using  (context = new Context()){
                context.Offices.Find(office_id).ProductsAvailable.Add(product);
                context.SaveChanges();
            }
        }

        public void ShipProduct(int office_id, int product_id){
            using (context = new Context()){
                Product item = context.Offices.Find(office_id).ProductsAvailable.Find(x => x.Id == product_id);
                if(item == null) return;
                context.Offices.Find(office_id).ProductsAvailable.Remove(item);
                context.SaveChanges();
            }
        }

    }

}