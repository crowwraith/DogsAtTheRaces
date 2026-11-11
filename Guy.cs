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
        private int number;
        public int Cash { get { return cash; } }
        
        public string name { get { return Name; } }
        public int Number { get { return number; } }
        public  Bet MyBet;

        //ui delen:
        private RadioButton MyRadioButton;
        private Label MyLabel;

        public Guy(string name, int cash, Label lb_guy1BetLabel, RadioButton rb_Guy1, int number)
        {
            Name = name;
            this.cash = cash;
            this.MyLabel = lb_guy1BetLabel;
            this.MyRadioButton = rb_Guy1;
            this.number = number;
        }
        public void UpdateLabels(int i)
        {
            // label checks where we are within the program so we can display different data while running the program. this should make sure we dont keep artifacts from past rounds.

            int label = i;
            // if checken wel/geen bet
            if (label == 1)
            {
                if (MyBet != null)
                {
                    MyLabel.Text = Name + " heeft " + MyBet.Amount.ToString() + " ingezet op hond nummer " + ( MyBet.Dog + 1 );
                }
                else
                {
                    MyLabel.Text = "heeft nog geen bet geplaatst";
                }
            }
            if(label == 2 && MyBet == null)
            {
               MyLabel.Text = Name + " heeft geen bet geplaatst";
            }                                      
        }

        public void ClearBet()
        {   
            MyBet = null;
        }
        public bool PlaceBet(int BetAmount, int DogToWin)
        {
            // maak nieuwe bet aan
            MyBet = new Bet(BetAmount,DogToWin,this);
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
