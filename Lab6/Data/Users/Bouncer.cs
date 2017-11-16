using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Timers;
using System.Windows.Threading;

namespace Lab6
{
    public class Bouncer : Agents
    {
        //Instances
        private Random random = new Random();

        //Delegates
        private Action<string, object> Logtext { get; set; }

        public Bouncer() : base()
        {
        }

        //Method to create Patrons and also to stop creating Patrons.
        public void Run(Action<string, object> logText)
        {
            //if timer is above 0, the bouncer creates patrons.
            if (Time.CurrentTime > 0)
            {
                Waiting(random.Next(3000, 10000));
                Task.Run(() =>
                {
                    Patron p = new Patron(10000, 20000); 
                    p.RunPatron(logText);
                });
            }
            //If timer is 0, the bouncer stops creating patrons.
            if (Time.CurrentTime == 0)
            {
                Logtext = logText;
                Logtext?.Invoke($"INKASTAREN HAR SLUTAT SLÄPPA IN GÄSTER", this);
                while (Time.CurrentTime == 0)
                {
                    Thread.Sleep(10);
                }
            }
        }
    }
}
