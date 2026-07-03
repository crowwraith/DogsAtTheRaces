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
        public int Dog = 0; // dog number
        public Guy Bettor; 

        public string GetDescription()
        {
            return ("bet"); // moet dalijk Bettor hebben, met een check of amount null is, null = no bet, anders waarde meegeven als bet.en vermelden welke dog het was.
        }

        public int PayOut(int winner)
        {
            if(winner == dog)
            {
                return Amount+Amount;
            }
        }
    }
}
