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
        public void Run(Action<string, object> logText, CancellationToken ct)
        {
            int patronRandomSleepDuration = random.Next(3, 10);

            while (!ct.IsCancellationRequested)
            {
                while (SimulationSettings.MySimulation().CreateBussLoadOfPatrons) // While-loop to let guests in at half speed rate and after 20 seconds creates 15 patrons
                {
                    patronRandomSleepDuration = random.Next(6, 20); // Variable to change sleeping time for generating Patrons
                    Waiting(patronRandomSleepDuration);
                    if (Time.CurrentTime <= Time.BussTimer - 20 && !SimulationSettings.MySimulation().HasBusBeenHere)
                    {
                        SimulationSettings.MySimulation().NumOfPatrons = 15;
                        GeneratePatrons(SimulationSettings.MySimulation().NumOfPatrons, logText); // Generates 15 patrons
                        SimulationSettings.MySimulation().HasBusBeenHere = true;
                    }
                    else
                    {
                        SimulationSettings.MySimulation().NumOfPatrons = 1;
                        GeneratePatrons(SimulationSettings.MySimulation().NumOfPatrons, logText); //Generates 1 patron
                    }
                    if (Time.CurrentTime == 0)
                        StopBouncer(logText);

                }
                if (Time.CurrentTime > 0)
                {
                    Waiting(patronRandomSleepDuration); //Creates patron every 3-10 second
                    GeneratePatrons(SimulationSettings.MySimulation().NumOfPatrons, logText);
                }
                else if (Time.CurrentTime == 0)
                    StopBouncer(logText);
            }
        }

        private void StopBouncer(Action<string, object> logText)
        {
            Logtext = logText;
            Logtext?.Invoke($"INKASTAREN HAR SLUTAT SLÄPPA IN GÄSTER", this);
            while (Time.CurrentTime == 0)
            {
                Thread.Sleep(10);
            }
        }

        private void GeneratePatrons(int count, Action<string, object> logText)
        {
            for (int i = 0; i < count; i++)
            {
                Task.Run(() =>
                {
                    Patron p = new Patron();
                    p.RunPatron(logText);
                });

            }
        }
    }
}
