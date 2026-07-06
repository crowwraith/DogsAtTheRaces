using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;


namespace DogsAtTheRaces
{
    public class Guy
    {
        public string Name { get; set; }
        public int Cash { get; set; }

        public Bet MyBet;

        //ui delen:
        public RadioButton MyRadioButton;
        public Label MyLabel;

        public Guy(string name, int cash)
        {
            Name = name;
            Cash = cash;
        }
        public void UpdateLabels()
        {
            
            //MyLabel.Text = Name;
            string money = Cash.ToString();
            //MyRadioButton.Text = money;
            // set my label to bet's description, radio button to show cash
        }

        public void ClearBet()
        {   
            // set bet to 0, use value out of mybet
            MyBet.Amount=0;
        }
        public bool PlaceBet(int BetAmount, int DogToWin)
        {
            // check of er genoeg geld is
            if (BetAmount <= 4 || BetAmount > Cash)
                return false;

            // maak nieuwe bet aan
            MyBet = new Bet();
            MyBet.Amount = BetAmount;
            MyBet.Dog = DogToWin-1;
            MyBet.Bettor = this;
            return true;
        }
        public void Collect(int Winner)
        {
            if (MyBet == null || MyBet.Amount == 0)
                return;
            Cash -= MyBet.Amount;
            int payout = MyBet.PayOut(Winner);
            Cash += payout;

            MyBet = null;
        }
    }
}
