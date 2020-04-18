using System;
namespace Software_Project.Data.Models
{

    public class Cart
    {

        public int Id { get; set; }
        public string User { get; set; }

        public List<Product> WishList { get; } = new List<Product>();
    }

}
