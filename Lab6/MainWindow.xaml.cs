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
using Lab6;

namespace Lab6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int increment = 1;
        public static Items<Chair> chairs;
        public static Items<Glass> glasses;
        public static Items<UsedGlass> usedGlasses;
        private static CancellationTokenSource cts = new CancellationTokenSource();
        public CancellationToken ct = cts.Token;

        public MainWindow()
        {
            InitializeComponent();

            // instantiate the generic Item variables
            chairs = new Items<Chair>();
            glasses = new Items<Glass>();
            usedGlasses = new Items<UsedGlass>();


            UsedGlass.maxNumOfUsedGlasses = Glass.maxNumOfGlasses;

            // Creating x amounts of items through function call.
            chairs.CreateItems(new Chair(), Chair.maxNumOfChairs);
            glasses.CreateItems(new Glass(), Glass.maxNumOfGlasses);
        }

        private void BtnOpenCloseBar_Click(object sender, RoutedEventArgs e)
        {
            BtnStop.IsEnabled = true;
            BtnOpenCloseBar.IsEnabled = false;
            //Bar timer
            Time.RunTimer(SimulationSettings.SimulationTime, SimulationSettings.SimulationSpeed);

            // Instantiate all the agents. Patrons is later created in the bouncer instance method
            Bouncer bouncer = new Bouncer();
            Bartender bartender = new Bartender();
            Waitress waitress = new Waitress(SimulationSettings.CollectionDuration, SimulationSettings.WashingDuration, SimulationSettings.AddToShelfDuration);

            // Bouncer/Patron Thread
            Task.Run(() => { bouncer.Run(AddList, ct); });
            // Bartender Thread
            Task.Run(() => { bartender.Handling(glasses, AddList, ct); });
            // Waitress Thread
            Task.Run(() => { waitress.Handling(usedGlasses, glasses, chairs, AddList, ct); });
            // Label Thread
            Task.Run(() => { UpdateLabels(); });
        }

        private void AddList(string action, object sender)
        {
            action = $"{increment++} {action}";
            Dispatcher.Invoke(() =>
            {
                switch (sender)
                {
                    case Patron _:
                        GuestListBox.Items.Insert(0, action);
                        break;
                    case Bartender _:
                        BartenderListBox.Items.Insert(0, action);
                        break;
                    case Waitress _:
                        WaiterListBox.Items.Insert(0, action);
                        break;
                    case Bouncer _:
                        GuestListBox.Items.Insert(0, action);
                        break;
                }
            });
        }

        // Update labels
        private void UpdateLabels()
        {
            while (!ct.IsCancellationRequested)
            {
                Dispatcher.Invoke(() =>
                {
                    GuestLabel1.Content = $"Number of guests: {Patron.NumOfGuests}";
                    ChairLabel.Content = $"Number of Chairs: {chairs.GetNumOfItems()}";
                    GlassLabel.Content = $"Number of glasses: {glasses.GetNumOfItems()}";
                    pubclosingLabel.Content = $"Pub closing in:";
                    TimerLabel.Content = Time.CurrentTime;
                });
                Thread.Sleep(10);
            }

            Dispatcher.Invoke(() =>
            {
                GuestLabel1.Content = "";
                ChairLabel.Content = "";
                GlassLabel.Content = "";
                TimerLabel.Content = "";
                pubclosingLabel.Content = "";
            });
        }

        private void SimulationSpeed_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Agents.SpeedModifier = Convert.ToInt32(SimulationSpeed.Value);
        }

        private void BtnStop_Click_1(object sender, RoutedEventArgs e)
        {
            BtnOpenCloseBar.IsEnabled = true;
            BtnStop.IsEnabled = false;
            GuestListBox.Items.Clear();
            BartenderListBox.Items.Clear();
            WaiterListBox.Items.Clear();
            cts.Cancel();
        }
    }
}

