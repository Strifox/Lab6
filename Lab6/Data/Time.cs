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
        public int CurrentTime { get; set; }

        public void RunTimer(int runTime)
        {
            CurrentTime = runTime;

            //Creating the timer in it's own task. 
            Task.Run(() =>
            {
                while (CurrentTime > 0)
                {

                    Thread.Sleep(1000); // sleep method to make the property CurrentTime tick once a second.
                    CurrentTime--;

                }
            });
        }
    }
}
