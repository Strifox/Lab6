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
        public Action<bool> CheckTimer { get; set; }
        public int? CurrentTime { get; set; }
        public void RunTimer(int runTime, Label timeLabel)
        {
            if (CurrentTime != null && CheckTimer != null)
            {
                Task.Factory.StartNew(() =>
                {
                    
                        for (var second = 0; second < runTime; second++)
                        {
                            Thread.Sleep(10);
                            CurrentTime = second;
                            timeLabel.Content = CurrentTime.ToString();
                        }
                    CheckTimer(false);
                });
            }
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
