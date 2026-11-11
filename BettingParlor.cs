using System;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Timers;
using System.Windows.Forms;

namespace DogsAtTheRaces;

public partial class BettingParlor : Form
{
    Guy[] guys = new Guy[3];
    Dog[] dogs = new Dog[4];
    public int usernumber = 0;
    public int racelengt;
    public int winner;
    public Random Randomizer = new Random();
    public BettingParlor()
    {
        InitializeComponent();

        guys[0] = new Guy("Joe", 50, lb_guy1BetLabel, rb_Guy1 , 0);
        guys[1] = new Guy("Bob", 75, lb_guy2BetLabel, rb_Guy2 , 1);
        guys[2] = new Guy("Al" , 45, lb_guy3BetLabel, rb_Guy3 , 2);

        for (int i = 0; i < guys.Length; i++) {guys[i].UpdateLabels(1);}

        racelengt = pb_raceTrack.Width;

        dogs[0] = new Dog(Randomizer, pb_dog1, racelengt);
        dogs[1] = new Dog(Randomizer, pb_dog2, racelengt);
        dogs[2] = new Dog(Randomizer, pb_dog3, racelengt);
        dogs[3] = new Dog(Randomizer, pb_dog4, racelengt);

    }
        // stuff for the race itself
    public void bt_race_Click(object sender, EventArgs e)
    {
        t_raceTimer.Start();
        foreach(Guy g in guys)
        {
            g.UpdateLabels(2);
        }
    }
    public void t_raceTimer_Tick(object sender, EventArgs e)
    {
        for (int i = 0; i < dogs.Length; i++)
        {
            if (dogs[i].Run() == true)
            {
                
                t_raceTimer.Stop();
                MessageBox.Show("hond nummer " + (i+1) + " heeft gewonnen");
                raceEnd();
                foreach (Guy g in guys)
                {
                    g.Collect(i);
                    g.ClearBet();
                    g.UpdateLabels(1);
                }
                return;

            }
        }
    }
    public void raceEnd()
    {
        for (int j = 0; j < dogs.Length; j++)
        {
            dogs[j].TakeStartingPosition();
        }
    }
        // buttons for pre race betting
    public void bt_bet_Click(object sender, EventArgs e)
    {
        string user = lb_name.Text;
        int dog = (int)num_dogNumber.Value;
        int betvalue = (int)numericUpDown1.Value;

        // hier moet een check bij komen om te kijken of de speler genoeg geld heeft, en dan kan de check weg bij de guys.placebet functie
        if (betvalue >= 4)
        {
            foreach (Guy g in guys)
                if (usernumber == g.Number && betvalue <= g.Cash)
                {
                    g.PlaceBet(betvalue, dog);
                    g.UpdateLabels(1);
                }
                else if (betvalue > g.Cash)
                {
                    MessageBox.Show("Niet genoeg geld!");
                    return;
                }
        }
    }
        public void rb_Guy3_CheckedChanged(object sender, EventArgs e)
    {
        if (rb_Guy3.Checked)
        {
            usernumber = 2;
            lb_name.Text = guys[2].Name +" heeft nu "+ guys[2].Cash + " cash";
        }
    }
    public void rb_Guy2_CheckedChanged(object sender, EventArgs e)
    {
        if (rb_Guy2.Checked)
        {
            usernumber = 1;
            lb_name.Text = guys[1].Name + " heeft nu " + guys[1].Cash + " cash";
        }
    }
    public void rb_Guy1_CheckedChanged(object sender, EventArgs e)
    {
        if (rb_Guy1.Checked)
        {
            usernumber = 0;
            lb_name.Text = guys[0].Name + " heeft nu " + guys[0].Cash + " cash";
        }
    }

}
