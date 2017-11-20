using System;
using System.Reflection.Emit;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using Label = System.Windows.Controls.Label;


namespace Lab6
{
    public class Time
    {
        //Property to be used for labels.
        public static int CurrentTime { get; set; }
        public static int BussTimer { get; set; }
        public static void RunTimer(int simulationTime, int simulationSpeed)
        {
            CurrentTime = simulationTime;
            BussTimer = simulationTime;

            //Creating the timer in it's own task. 
            Task.Run(() =>
            {
                while (CurrentTime > 0)
                {
                    Agents.Waiting(simulationSpeed); // Simulation modifier used to change timer speed.
                    CurrentTime--;
                }
            });
        }
    }
}
