namespace Calculator.Views{

    public class Display{

        public decimal Amount { get; set; }
        public decimal Percent { get; set; }
        public decimal Tip { get; set; }
        public decimal Total { get; set; }

        public Display() {

            Amount = 0;
            Percent = 0;
            Tip = 0;
            Total = 0;
            GetValues();

        }

        private void GetValues() {

            System.Console.Write("Amount: ");
            Amount = decimal.Parse(System.Console.ReadLine());
            System.Console.Write("Percent: ");
            Percent = decimal.Parse(System.Console.ReadLine());

        }

        public void Show_Tip_And_Amount(){

            System.Console.WriteLine("The tip is: {0:C}", Tip);
            System.Console.WriteLine("The total is: {0:C}", Total);

        }

    }
    
}