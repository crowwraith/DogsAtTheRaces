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
    public bool betstats1;
    public bool betstats2;
    public bool betstats3;
    public BettingParlor()
    {
        InitializeComponent();

        guys[0] = new Guy("Joe", 50, lb_guy1BetLabel, rb_Guy1);
        guys[1] = new Guy("Bob", 75, lb_guy2BetLabel, rb_Guy2);
        guys[2] = new Guy("Al" , 45, lb_guy3BetLabel, rb_Guy3 );

        for (int i = 0; i < guys.Length; i++) {guys[i].UpdateLabels();}

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

        if (betstats1 == false)
        {
            lb_guy1BetLabel.Text = "Joe heeft geen bet geplaatst";
        }
        if (betstats2 == false)
        {
            lb_guy2BetLabel.Text = "Bob heeft geen bet geplaatst";
        }
        if (betstats3 == false)
        {
            lb_guy3BetLabel.Text = "Al heeft geen bet geplaatst";
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
                    g.UpdateLabels();
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
        betstats3 = false;
        betstats2 = false;
        betstats1 = false;
    }


    // buttons for pre race betting
    public void bt_bet_Click(object sender, EventArgs e)
    {
        string user = lb_name.Text;
        int dog = (int)num_dogNumber.Value;
        int betvalue;
        // hier moet een check bij komen om te kijken of de speler genoeg geld heeft, en dan kan de check weg bij de guys.placebet functie

        if (usernumber == 0) {
            betvalue = (int)numericUpDown1.Value;
            lb_guy1BetLabel.Text = "joe heeft " + betvalue.ToString() + " ingezet op hond nummer " + dog;
            if (!guys[usernumber].PlaceBet(betvalue, dog))
            {
                MessageBox.Show("Niet genoeg geld!");
                return;
            }
            // check ook of speler genoeg geld heeft -> gebeurt nog niet
            betstats1 = true;            
        }
        if (usernumber == 1)
        {
            betvalue = (int)numericUpDown1.Value;
            lb_guy2BetLabel.Text = "Bob heeft " + betvalue.ToString() + " ingezet op hond nummer " + dog;
            guys[usernumber].PlaceBet(betvalue, dog);
            betstats2 = true;
        }
        if (usernumber == 2)
        {
            betvalue = (int)numericUpDown1.Value;
            lb_guy3BetLabel.Text = "Al heeft " + betvalue.ToString() + " ingezet op hond nummer " + dog;
            guys[usernumber].PlaceBet(betvalue, dog);
            betstats3 = true;
        }

            // wisselende namen linken aan cijfer, daarna usernumber vergelijken met for loop zodat we de text 1 keer gebruiken?
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
