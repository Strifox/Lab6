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
using Lab6.Data;
using Lab6.Data.Users;

namespace Lab6.Data
{
    public class Time
    {

        private static void BarTimerTick(object sender, EventArgs e, Action<string> WriteToLabel)
        {
          WriteToLabel(DateTime.Now.ToLongTimeString());
              
        }
        public static void InitializeTimer(int timer)
        {
           
            DispatcherTimer barTimer = new DispatcherTimer();
            barTimer.Interval = new TimeSpan(timer);
            barTimer.Tick -= BarTimerTick;
            
            if (barTimer != null)
            {
                MainWindow initiliazePub = new MainWindow();
                initiliazePub.InitializeComponent();
            }

        }
    }
}
