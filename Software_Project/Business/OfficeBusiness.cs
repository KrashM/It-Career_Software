using Software_Project.Data;
using Software_Project.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Software_Project.Business{

    static class OfficeBusiness{

        private static Context context;

        public static int GetID(string name){
            using (context = new Context()){
                return context.Offices.ToList().Find(x => x.Name == name).Id;
            }
        }

        public static int GetStock(int officeID, int productID){
            using (context = new Context()) {
                return context.Office_Products.ToList().Find(x => (x.OfficeID == officeID) && (x.ProductID == productID)).Stock;
            }
        }

        public static bool OfficeExists(string name){
            using (context = new Context()){
                return context.Offices.Any(x => x.Name == name); 
            }
        }

        public static void CreateOffice(string name, string city, string address, string phone) { 
            using (context = new Context()) {
                Office office = new Office();
                office.Name = name;
                office.City = city;
                office.Address = address;
                office.Phone = phone;
                context.Offices.Add(office);
                context.SaveChanges();
            }
        }

        public static bool CityExists(string city){
            using (context = new Context()){
                return context.Offices.Any(x => x.City == city);
            }
        }

        public static bool ProductAvailable(int officeID, int productID){
            using (context = new Context()){
                return context.Office_Products.Any(x => (x.OfficeID == officeID) && (x.ProductID == productID));
            }
        }

        public static List<Office> GetAllOffices(){
            using (context = new Context()){
                return context.Offices.ToList();
            }
        }

        public static List<Product> AllProductsAvailableInOffice(int id){
            using (context = new Context()){
                return context.Products.ToList().FindAll(x => context.Office_Products.ToList().FindAll(x => x.OfficeID == id).Select(x => x.ProductID).Contains(x.Id));
            }
        }

        public static List<Office> AllOfficesInACity(string city){
            using (context = new Context()){
                List<Office> officesInThatCity = new List<Office>();
                foreach(Office office in context.Offices)
                    if(office.City == city)
                        officesInThatCity.Add(office);
                return officesInThatCity;
            }
        }

        public static void LoadProduct(int id, Product product, int stock){
            using  (context = new Context()){
                Office_Product office_Product = new Office_Product();
                office_Product.ProductID = product.Id;
                office_Product.OfficeID = id;
                office_Product.Stock = stock;
                context.Office_Products.Add(office_Product);
                context.SaveChanges();
            }
        }

        public static void TransferProduct(int oldOfficeID, int newOfficeID, int productID){
            using (context = new Context()){
                context.Office_Products.ToList().Find(x => (x.OfficeID == oldOfficeID) && (x.ProductID == productID)).OfficeID = newOfficeID;
                context.SaveChanges();
            }
        }

        public static void ShipProduct(int id, int productID, int amount){
            using (context = new Context()){
                if(context.Office_Products.ToList().Find(x => (x.OfficeID == id) && (x.ProductID == productID)).Stock < amount) return;
                context.Office_Products.ToList().Find(x => (x.OfficeID == id) && (x.ProductID == productID)).Stock -= amount;
                context.SaveChanges();
            }
        }

    }

}