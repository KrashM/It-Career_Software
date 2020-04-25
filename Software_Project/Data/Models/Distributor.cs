using Software_Project.Business;

namespace Software_Project.Data.Models{

    public class Distributor{

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public override string ToString(){
            return $"Distributor: {Name}\nAddress: {Address}\nEmail: {Email}\nPhone: {Phone}\nProducts that they distribute:\n{string.Join("\n", DistributorBusiness.GetProducts(Id))}";
        }

    }

}
