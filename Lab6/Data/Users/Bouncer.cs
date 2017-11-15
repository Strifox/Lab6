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
        private Random random = new Random();
        public Bouncer() : base()
        {
            //Callback(namesList[random.Next(namesList.Count)]);
            //BounceGuests();
        }

        public void Run(Action<string, object> logText)
        {
            Thread.Sleep(random.Next(3, 10) * 1000);
            Task.Run(() =>
            {
                Patron p = new Patron(10000, 20000);
                p.RunPatron(logText);
            });

        }
    }
}
