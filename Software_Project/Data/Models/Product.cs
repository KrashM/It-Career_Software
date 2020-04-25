namespace Software_Project.Data.Models{

    public class Product{

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int DistributorID { get; set; }

        public override string ToString(){
            return $"Name: {Name}\nCosts: {Price}";
        }
      
    }

}