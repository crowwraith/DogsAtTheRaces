using System;
using System.Collections.Generic;
using System.Linq;
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
            // place new bet and store in bet field, return true if enough money to place bet
            if (MyBet == null) return false;//placeholders
            else return true;//placeholders since bet doesnt excist yet
        }
        public void Collect( int Winner)
        {
            int number = Winner;
            MyBet.PayOut(number);
        }
    }
}
