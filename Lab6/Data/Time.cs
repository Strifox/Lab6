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
        public int CurrentTime { get; set; }
        public void RunTimer(int runTime)
        {
            CurrentTime = runTime;
            Task.Run(() =>
            {
                while (CurrentTime > 0)
                {

                    Thread.Sleep(1000);
                    CurrentTime--;

                }
            });


        }

        //private int increment;
        //public  int Increment { get { return increment; } set { increment = value; } }
        //public Label TimeLabel { get; set; }
        //public  void BarTimerStart()
        //{

        //    DispatcherTimer barTimer = new DispatcherTimer()
        //    {
        //        Interval = TimeSpan.FromSeconds(1)
        //    };
        //    barTimer.Tick += BarTimerTicker;
        //    barTimer.Start();
        //}

        //private void BarTimerTicker(object sender, EventArgs e)
        //{
        //    increment++;
        //    TimeLabel.Content = increment.ToString();

        //}
    }
}
