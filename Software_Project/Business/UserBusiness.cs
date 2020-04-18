using Software_Project.Data;
using Software_Project.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Software_Project.Business{

    class UserBusiness{

        private Context context;

        public List<User> GetAllUsers(){
            using (context = new Context()){
                return context.Users.ToList();
            }
        }

        public void Register(User user){
            using (context = new Context()){
                context.Users.Add(user);
                context.SaveChanges();
            }
        }

        public void RemoveUser(User user){
            using (context = new Context()){
                User deleated = context.Users.Find(user);
                if(deleated == null) return;
                context.Users.Remove(deleated);
                context.SaveChanges();
            }
        }

        public void UpdateMoney(User user){
            using (context = new Context()){
                context.Users.Update(user);
                context.SaveChanges();
            }
        }

    }

}