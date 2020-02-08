using Calculator.Models;
using Calculator.Views;

namespace Calculator.Controllers{

    public class Controller{

        private Tip tip;
        private Display display;

        public Controller(){

            display = new Display();
            tip = new Tip(display.Amount, display.Percent);

            display.Tip = tip.Calculate_Tip();
            display.Total = tip.Calculate_Total();

            display.Show_Tip_And_Amount();

        }

    }
    
}