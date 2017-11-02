using System;
using System.Windows;
using System.Windows.Threading;


namespace Lab6
{
    public static class Time
    {
        static MainWindow Form = Application.Current.MainWindow as MainWindow;
        private static int increment;
        public static int Increment { get { return increment; } set { increment = value; } }
        public static void BarTimerStart()
        {

            DispatcherTimer barTimer = new DispatcherTimer()
            {
                Interval = TimeSpan.FromSeconds(1)
            };
            barTimer.Tick += BarTimerTicker;
            barTimer.Start();
        }

        private static void BarTimerTicker(object sender, EventArgs e)
        {
            increment++;
            Form.TimerLabel.Content = increment.ToString();
        }

    }
}
