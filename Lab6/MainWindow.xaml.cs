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
        private int increment = 1;
        private Items<Chair> chairs;
        private Items<Glass> glasses;

        private static CancellationTokenSource cts = new CancellationTokenSource();
        public CancellationToken ct = cts.Token;

        public MainWindow()
        {
            InitializeComponent();

            chairs = new Items<Chair>();
            glasses = new Items<Glass>();

            chairs.CreateItems(new Chair(), 8);
            glasses.CreateItems(new Glass(), 9);
        }

        private void GuestListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void BtnOpenCloseBar_Click(object sender, RoutedEventArgs e)
        {
            ChairLabel.Content = $"Number of chairs: {chairs.GetNumOfItems().ToString()}";
            GlassLabel.Content = $"Number of glasses: {glasses.GetNumOfItems().ToString()}";
            GuestLabel1.Content = $"Number of guests: {Patron.numOfGuests.ToString()}";
            Time.BarTimerStart();
            Bouncer b = new Bouncer();
            Task.Run(() =>
            {
                while (!ct.IsCancellationRequested)
                {
                    b.Run(AddList, NumOfGuests); 
                }
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

        private void NumOfGuests()
        {
            Dispatcher.Invoke(() =>
            {
                GuestLabel1.Content = $"Number of guests: {Patron.numOfGuests.ToString()}";
            });
        }
    }
}

