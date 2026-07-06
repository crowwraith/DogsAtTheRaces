using System;
using System.Security.Cryptography.X509Certificates;
using System.Timers;
using System.Windows.Forms;

namespace DogsAtTheRaces;

public partial class BettingParlor : Form
{
    Guy[] guys = new Guy[3];
    Dog[] dogs = new Dog[4];
    public int usernumber = 0;
    public Random Randomizer = new Random();
    //private System.Windows.Forms.Timer timer;

    public BettingParlor()
    {
        InitializeComponent();

        guys[0] = new Guy("Joe", 50);
        guys[1] = new Guy("Bob", 75);
        guys[2] = new Guy("Al", 45);
        guys[0].UpdateLabels();
        guys[1].UpdateLabels();
        guys[2].UpdateLabels();



        dogs[0] = new Dog(Randomizer);
        dogs[1] = new Dog(Randomizer);
        dogs[2] = new Dog(Randomizer);
        dogs[3] = new Dog(Randomizer);

        //// Initialize Timer
        //timer = new System.Windows.Forms.Timer();
        //timer.Interval = 1000; // 1 second
        //timer.Tick += OnTimerTick;
        //timer.Start();

    }
    //public void timer_tick()
    //{// loop trough doggies, instead of number
    //    for (int i = 0; i < 3; i++)
    //    {
    //        if (dogs[i].Run() == true)
    //        {
    //            int winner = i;
    //            Console.WriteLine(i);
    //        }
    //    }
    //}


    public void bt_race_Click(object sender, EventArgs e)
    {
        t_raceTimer.Start();
        for (int i = 0; i < dogs.Length; i++)
        {
            if (dogs[i].Run() == true)
            {
                int winner = i;
                Console.WriteLine("hond nummer"+winner+ 1 + "heeft gewonnen");
            }
        }

    }

    public void bt_bet_Click(object sender, EventArgs e)
    {
        string user = lb_name.Text;
        int dog = (int)num_dogNumber.Value;
        int betvalue = (int)numericUpDown1.Value;
        
        if (usernumber == 0) {
            lb_guy1BetLabel.Text = usernumber + "" + betvalue.ToString(); 
        }
        else if (usernumber == 1)
        {
            lb_guy2BetLabel.Text = usernumber + "" + betvalue.ToString();
        }
        else if (usernumber == 2)
        {
            lb_guy3BetLabel.Text = usernumber + "" + betvalue.ToString();
        }
        guys[usernumber].PlaceBet(betvalue, dog);
        
    }

    public void t_raceTimer_Tick(object sender, EventArgs e)
    {
        
        
    }

    public void rb_Guy3_CheckedChanged(object sender, EventArgs e)
    {
        if (rb_Guy3.Checked)
        {
            usernumber = 2;
            lb_name.Text = guys[2].Name;
        }
    }

    public void rb_Guy2_CheckedChanged(object sender, EventArgs e)
    {
        if (rb_Guy2.Checked)
        {
            usernumber = 1;
            lb_name.Text = guys[1].Name;
        }
    }

    public void rb_Guy1_CheckedChanged(object sender, EventArgs e)
    {
        if (rb_Guy1.Checked)
        {
            usernumber = 0;
            lb_name.Text = guys[0].Name;
        }
    }
}
