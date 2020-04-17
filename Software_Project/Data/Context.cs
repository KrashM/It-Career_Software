using Microsoft.EntityFrameworkCore;
using Software_Project.Data.Models;

namespace Software_Project.Data{

    public class Context : DbContext{

        public Context():base(){}

        public DbSet<Product> Products { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS; Database=Project_Shop_DB; Integrated Security=true;");
        }

    }

}