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
        public int StartingPositioin =0;
        public int RacetrackLength;
        public int Location;
        public PictureBox MyPictureBox;
        public Random Randomizer; // maakt anders een random aan voor elke hond, moest er maar 1 zijn. dus aanmaken op bettingparlor zelf en dan meegeven.

        private int counts;
        public Dog(Random random, PictureBox mypic, int racelength)
        {
          Randomizer = random;
          MyPictureBox = mypic;
          RacetrackLength = racelength - 120;
          
        }
        public bool Run()
        {
            counts = Randomizer.Next(11, 19);
            Location += counts;
            MyPictureBox.Left = StartingPositioin + Location;
            if (Location >= RacetrackLength)
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
            Location = 0;
            MyPictureBox.Left = StartingPositioin;
            

        }
        
    }
}
