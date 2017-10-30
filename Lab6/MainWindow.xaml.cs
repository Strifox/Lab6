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
using System.Timers;
using System.Windows.Threading;
using Lab6.Data;
using Lab6.Data.Users;

namespace Lab6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
           InitializeComponent();
        }

        private static void BarTimer(int timer)
        {
            DispatcherTimer barTimer = new DispatcherTimer();
            barTimer.Interval = new TimeSpan(timer);
            barTimer.Tick -= BarTimerTick;
        }
        private class EventHantHandler BarTimerTick(Action<string> WriteToLabel)
        {
            WriteToLabel(DateTime.Now.ToLongTimeString());

        }
        private void GuestListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void BtnOpenCloseBar_Click(object sender, RoutedEventArgs e)
        {
            TimerLabel.Content = DateTime.Now.ToLongTimeString();
            Task.Run(() =>
            {
                Dispatcher?.Invoke(() =>
                {
                    Random random = new Random();
                    Thread.Sleep(random.Next(3000, 10000));
                    var p = new Patron();
                    GuestListBox.Items.Add(p.Behaviours());
                });


            });
                
        }
    }
}
