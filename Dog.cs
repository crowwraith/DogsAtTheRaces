using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogsAtTheRaces
{
    public class Dog
    {
        public int StartingPositioin;
        public int RacetrackLength;
        public int Location = 0;
        public PictureBox MyPictureBox = null;
        public Random Randomizer;

        public bool Run()
        {
            MyPictureBox.Left = StartingPositioin + Location;
            if (StartingPositioin+Location >= RacetrackLength)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void TakeStartingPosition()
        {
            MyPictureBox.Left = 0;

        }
    }
}
