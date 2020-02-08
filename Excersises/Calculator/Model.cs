namespace Calculator.Models{

    public class Tip {

        private decimal amount;
        private decimal percent;

        public decimal Amount { get => amount; set => amount = value; }
        public decimal Percent { get => percent; set => percent = (value > 1) ? value / 100.0m : value; }

        public Tip(decimal amount, decimal percent){
            
            Amount = amount;
            Percent = percent;

        }
        public Tip() : this(0,0) { }

        public decimal Calculate_Tip(){

            return Amount * Percent;

        }

        public decimal Calculate_Total(){

            return Amount + Amount * Percent;

        }

    }

}