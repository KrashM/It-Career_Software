using System.Collections.Generic;

namespace Software_Project.Data.Models{

    public class Office{
        
        public int Id { get; set; }
        public string City { get; set; }
        public List<Product> ProductsAvailable { get; } = new List<Product>();
        public List<Distributor> DistributorsLoadingTheOffice { get; } = new List<Distributor>();
        
    }
}
