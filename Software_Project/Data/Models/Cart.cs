using System.Collections.Generic;
using System.Linq;

namespace Software_Project.Data.Models{

    public class Cart{

        public int Id { get; set; }
        public List<Product> Products { get; } = new List<Product>();

        public decimal Sum(){

            decimal sum = Products.Select(x => x.Price).Sum();
            return sum;

        }

    }

}
