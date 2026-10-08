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
        public string Name { get; }
        private int cash;
        public int Cash { get { return cash; } }
        
        public string name { get { return Name; } }
        public Bet MyBet;

        //ui delen:
        private RadioButton MyRadioButton;
        private Label MyLabel;

        public Guy(string name, int cash, Label lb_guy1BetLabel, RadioButton rb_Guy1)
        {
            Name = name;
            this.cash = cash;
            this.MyLabel = lb_guy1BetLabel;
            this.MyRadioButton = rb_Guy1;
            // betstats to update label with after race end should move here. 
        }
        public void UpdateLabels()
        {
            // if checken wel/geen bet
            if (MyBet != null)
            {
                MyLabel.Text = Name +" heeft " + MyBet.Amount.ToString() + " ingezet op hond nummer " + MyBet.Dog;
            }
            else
            {
                MyLabel.Text = "nog geen bet geplaatst";
            }
        }

        public void ClearBet()
        {   
            // set bet to 0, use value out of mybet
            MyBet = null;
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
            int payout = MyBet.PayOut(Winner);
            cash += payout;
        }
    }
}
