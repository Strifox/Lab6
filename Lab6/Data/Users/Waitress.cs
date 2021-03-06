﻿using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
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
    public class Waitress : Agents
    {
        //Private fields to change Thread.Sleep in Handling method
        private int CollectDuration { get; set; } //The time it takes to pick up empty glasses
        private int WashingDuration { get; set; } //The time it takes to clean the glasses
        private int AddToShelfDuration { get; set; } //The time it takes to add glasses to the shelf


        public void Handling(Items<UsedGlass> usedGlasses, Items<Glass> glasses, Items<Chair> chairs, Action<string, object> updateListBox, CancellationToken ct)
        {
            while (!ct.IsCancellationRequested)
            {
                if (usedGlasses.itemQueue.Count > 0)
                {
                    updateListBox("Plockar tomma glas", this);
                    Waiting(CollectDuration);
                    updateListBox("Rengör glasen", this);
                    Waiting(WashingDuration);
                    updateListBox("Lägger tillbaka glasen i hyllan", this);
                    Waiting(AddToShelfDuration);
                    foreach (var usedGlass in usedGlasses.itemQueue)
                    {
                        usedGlasses.itemQueue.Take();
                        glasses.itemQueue.Add(new Glass());
                    }
                }
                if (Time.CurrentTime == 0 && Patron.CurrentNumOfGuests == 0 && usedGlasses.itemQueue.Count == 0)
                {
                    updateListBox("Allt är rent, Puben stängs och servitrisen går hem", this);
                    while (Time.CurrentTime == 0 && Patron.CurrentNumOfGuests == 0)
                        Thread.Sleep(100);
                }
                if (usedGlasses.itemQueue.Count == 0)
                {
                    updateListBox("Väntar på disk", this);
                    while (!usedGlasses.itemQueue.Any())
                        Thread.Sleep(100);
                }
            }
        }

        public Waitress(int collectDuration, int washingDuration, int addToShelfDuration) : base()
        {
            CollectDuration = collectDuration;
            WashingDuration = washingDuration;
            AddToShelfDuration = addToShelfDuration;
        }

    }
}
