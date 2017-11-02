using System;
using System.Collections.Concurrent;
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

namespace Lab6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ConcurrentQueue<Patron> BeerQueue = new ConcurrentQueue<Patron>();
        ConcurrentQueue<Patron> ChairQueue = new ConcurrentQueue<Patron>();
        public CancellationTokenSource cts;
        public CancellationToken ct;
        private int increment = 1;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void GuestListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void BtnOpenCloseBar_Click(object sender, RoutedEventArgs e)
        {
            Time.BarTimerStart();
            Bouncer b = new Bouncer(AddList);
            Task.Run(() =>
            {
                b.Run(AddList);
            });
        }

        private void AddList(string obj)
        {
            obj = $"{increment++} {obj}";
            Dispatcher.Invoke(() =>
            {

                GuestListBox.Items.Insert(0, obj);
            });
        }
    }
}

