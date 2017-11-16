using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;


namespace Lab6
{
    public class Time
    {
        //static MainWindow Form = Application.Current.MainWindow as MainWindow;
        //private static int increment;
        //public static int Increment { get { return increment; } set { increment = value; } }
        //public static void BarTimerStart()
        //{

        //    DispatcherTimer barTimer = new DispatcherTimer()
        //    {
        //        Interval = TimeSpan.FromSeconds(1)
        //    };
        //    barTimer.Tick += BarTimerTicker;
        //    barTimer.Start();
        //}

        //private static void BarTimerTicker(object sender, EventArgs e)
        //{
        //    increment++;
        //    Form.TimerLabel.Content = increment.ToString();
        //}

        private bool checkTimer = false;
        private long? Seconds { get; set; }
        public long? Increment { get; set; }

        public void RunTimer(int timer)
        {
            Task.Run(() =>
            {
                if (!checkTimer)
                {
                    Seconds = timer;
                    for (int seconds = timer; Seconds < Increment; Seconds++)
                    {
                        seconds++;
                        Increment = seconds;
                    }

                }
            });
        }

    }
}
