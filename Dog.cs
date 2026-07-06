using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
        public Random Randomizer; // maakt anders een random aan voor elke hond, moest er maar 1 zijn. dus aanmaken op bettingparlor zelf en dan meegeven.

        public Dog(Random random)
        {
          Randomizer = random;
        }
        public bool Run()
        {
            Location = Randomizer.Next(1, 5);
            MyPictureBox.Left = StartingPositioin += Location;
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
