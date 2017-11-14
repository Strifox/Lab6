﻿using System;
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
        public static Items<Chair> chairs;
        public static Items<Glass> glasses;

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
            Time.BarTimerStart();
            if (BtnOpenCloseBar.Content.ToString() == ("Open"))

                BtnOpenCloseBar.Content = "Close";
            else

                BtnOpenCloseBar.Content = "Open";
            
            //BtnOpenCloseBar.Background
            ChairLabel.Content = $"Number of chairs: {chairs.GetNumOfItems().ToString()}";
            GlassLabel.Content = $"Number of glasses: {glasses.GetNumOfItems().ToString()}";
            GuestLabel1.Content = $"Number of guests: {Patron.numOfGuests.ToString()}";
            Bouncer b = new Bouncer();
            Bartender bartender = new Bartender();
            Task.Run(() =>
            {
                while (!ct.IsCancellationRequested)
                {
                    b.Run(AddList); 
                }
            });

            Task.Run(() =>
            {
                while (!ct.IsCancellationRequested)
                {
                    bartender.Handling(glasses, AddList);
                }
            });

            Task.Run(() =>
            {
                UpdateLabels();
            });
        }

        private void AddList(string action, object sender)
        {
            Patron s = new Patron();
            Bartender b = new Bartender();
            Waitress w = new Waitress();
            action = $"{increment++} {action}";
            Dispatcher.Invoke(() =>
            {
                if (sender.GetType() == s.GetType())
                    GuestListBox.Items.Insert(0, action);
                if (sender.GetType() == b.GetType())
                    BartenderListBox.Items.Insert(0, action);
                if (sender.GetType() == w.GetType())
                    WaiterListBox.Items.Insert(0, action);
            });
        }

        private void UpdateLabels()
        {
            while (!ct.IsCancellationRequested)
            {
                Dispatcher.Invoke(() =>
                {
                    GuestLabel1.Content = $"Number of guests: {Patron.numOfGuests.ToString()}";
                    ChairLabel.Content = $"Number of Chairs: {chairs.GetNumOfItems().ToString()}";
                    GlassLabel.Content = $"Number of glasses: {glasses.GetNumOfItems().ToString()}";
                });
            }
        }
    }
}

