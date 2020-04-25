using Software_Project.Data;
using Software_Project.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Software_Project.Business{

    static class UserBusiness{

        private static Context context;

        public static int GetID(string username){
            using (context = new Context()){
                return context.Users.ToList().Find(x => x.Username == username).Id;
            }
        }

        public static List<User> GetAllUsers(){
            using (context = new Context()){
                return context.Users.ToList();
            }
        }

        public static User GetUser(int userID){
            using (context = new Context()){
                return GetAllUsers().Find(x => x.Id == userID);
            }
        }

        public static bool CheckForUser(int userID){
            using (context = new Context()){
                return context.Users.ToList().Any(x => x.Id == userID);
            }
        }

        public static string GetUserPassword(int userID){
            using (context = new Context()){
                return context.Users.ToList().Find(x => x.Id == userID).Password;
            }
        }

        public static void Register(string username, string password){
            using (context = new Context()){
                User newUser = new User();
                newUser.Username = username;
                newUser.Password = password;
                newUser.Balance = 0;
                context.Users.Add(newUser);
                context.SaveChanges();
            }
        }

        public static void RemoveUser(int userID){
            using (context = new Context()){
                User deleated = context.Users.ToList().Find(x => x.Id == userID);
                if(deleated == null) return;
                context.Users.Remove(deleated);
                context.SaveChanges();
            }
        }

        public static void UpdateMoney(int userID, decimal amount){
            using (context = new Context()){
                User testificate = context.Users.ToList().Find(x => x.Id == userID);
                if (testificate == null) return;
                testificate.Balance += amount;
                context.SaveChanges();
            }
        }

    }

}