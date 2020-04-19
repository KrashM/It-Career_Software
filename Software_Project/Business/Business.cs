using Software_Project.Data;
using Software_Project.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Software_Project.Business{

    class UserBusiness{

        private Context context;

        public List<User> GetAllUsers(){
            using(context = new Context()){
                return context.Users.ToList();
            }
        }

        public void Register(User user){

            using (context = new Context()){
                context.Users.Add(user);
                context.SaveChanges();
            }

        }

        public void Money(User user){

            using (context = new Context()){
                context.Users.Update(user);
                context.SaveChanges();
            }

        }

        public List<Product> GetAllProducts(){
            using(context = new Context()){
                return context.Products.ToList();
            }
        }

        public Product GetProduct(int id){
            return new Product();
        }

        public void Add(Product product){

        }

        public void Update(Product product){

        }

        public void Delete(int id){

        }

    }

}