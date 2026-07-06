using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DogsAtTheRaces
{
    public class Bet
    {
        public int Amount;
        public int Dog; // dog number
        public Guy Bettor; 

        public string GetDescription()
        {
            return ("bet"); // moet dalijk Bettor hebben, met een check of amount null is, null = no bet, anders waarde meegeven als bet.en vermelden welke dog het was.
        }

        public int PayOut(int winner)
        {
            if (Amount == 0)
                return 0;

            if (winner == Dog)
                return Amount * 2;
            else
                return 0;
        }
    }
}
