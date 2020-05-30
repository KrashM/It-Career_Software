using Software_Project.Data;
using Software_Project.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Software_Project.Business{

    static class UserBusiness{

        private static Context context;

        /// <summary>
        /// Gets the ID of a specific user.
        /// </summary>
        /// <param name="username"></param>
        /// <returns>The ID of the user found.</returns>
        public static int GetID(string username){
            using (context = new Context()){
                return context.Users.ToList().Find(x => x.Username == username).Id;
            }
        }

        /// <summary>
        /// Gets a list of all the users.
        /// </summary>
        /// <returns>List of users.</returns>
        public static List<User> GetAllUsers(){
            using (context = new Context()){
                return context.Users.ToList();
            }
        }

        /// <summary>
        /// Gets a specific user.
        /// </summary>
        /// <param name="userID"></param>
        /// <returns>The user found.</returns>
        public static User GetUser(int userID){
            using (context = new Context()){
                return GetAllUsers().Find(x => x.Id == userID);
            }
        }

        /// <summary>
        /// Checks if a specific user exists.
        /// </summary>
        /// <param name="userID"></param>
        /// <returns>True or false.</returns>
        public static bool CheckForUser(int userID){
            using (context = new Context()){
                return context.Users.ToList().Any(x => x.Id == userID);
            }
        }

        /// <summary>
        /// Gets the password of a specific user.
        /// </summary>
        /// <param name="userID"></param>
        /// <returns>The hashed password of the user.</returns>
        public static string GetUserPassword(int userID){
            using (context = new Context()){
                return context.Users.ToList().Find(x => x.Id == userID).Password;
            }
        }

        /// <summary>
        /// Creates a new user in the system.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
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

        /// <summary>
        /// Removes a user from the system.
        /// </summary>
        /// <param name="userID"></param>
        public static void RemoveUser(int userID){
            using (context = new Context()){
                User deleated = context.Users.ToList().Find(x => x.Id == userID);
                if(deleated == null) return;
                context.Users.Remove(deleated);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Updates the balance of a specified user by the given amount.
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="amount"></param>
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