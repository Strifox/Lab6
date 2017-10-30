using System;
using System.Collections.Generic;
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
using System.Windows.Threading;

namespace Lab6
{
    public static class Time
    {
        static MainWindow Form = Application.Current.MainWindow as MainWindow;
        private static int increment = 0;

        public static void BarTimer()
        {
            DispatcherTimer barTimer = new DispatcherTimer();
            barTimer.Interval = TimeSpan.FromSeconds(1);
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
