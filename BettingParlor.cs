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

        guys[0] = new Guy("Joe", 50);
        guys[1] = new Guy("Bob", 75);
        guys[2] = new Guy("Al", 45);
        guys[0].UpdateLabels();
        guys[1].UpdateLabels();
        guys[2].UpdateLabels();

        racelengt = pb_raceTrack.Width;

        dogs[0] = new Dog(Randomizer, pb_dog1);
        dogs[1] = new Dog(Randomizer, pb_dog2);
        dogs[2] = new Dog(Randomizer, pb_dog3);
        dogs[3] = new Dog(Randomizer, pb_dog4);

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
            if (dogs[i].Run(racelengt) == true)
            {
                winner = i;
                Console.WriteLine("hond nummer" + (winner+1) + "heeft gewonnen");
                t_raceTimer.Stop();
                MessageBox.Show("hond nummer" + (winner+1) + "heeft gewonnen");
                raceEnd();
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
        lb_guy1BetLabel.Text = "nog geen bet geplaatst";
        lb_guy2BetLabel.Text = "nog geen bet geplaatst";
        lb_guy3BetLabel.Text = "nog geen bet geplaatst";
        foreach (Guy g in guys)
        {
            g.Collect(winner);
        }
    }


    // buttons for pre race betting

    public void bt_bet_Click(object sender, EventArgs e)
    {
        string user = lb_name.Text;
        int dog = (int)num_dogNumber.Value;
        int betvalue;

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
