namespace Software_Project.Data.Models{

    public class User{

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public float Balance { get; set; } = 0;
        //public List<Product> WishList { get; } = new List<Product>();

    }

}
