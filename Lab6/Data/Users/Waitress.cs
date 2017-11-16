using System;
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


        public void Handling(Items<UsedGlass> usedGlasses, Items<Glass> glasses, Items<Chair> chairs, Action<string, object> updateListBox)
        {
            // Updates label on GUI with following text
            if (usedGlasses.itemQueue.Count > 0)
            {
                updateListBox("Plockar tomma glas", this);
                Waiting(CollectDuration); //Sleep duration
                updateListBox("Rengör glasen", this);
                Waiting(WashingDuration); //Sleep duration
                updateListBox("Lägger tillbaka glasen i hyllan", this);
                Waiting(AddToShelfDuration); //Sleep duration

                foreach (var usedGlass in usedGlasses.itemQueue)
                {
                    usedGlasses.itemQueue.Take(); // Removes one used glass from the used glasses queue
                    glasses.itemQueue.Add(new Glass()); // Adds a new glass item to the glass queue
                }
            }
            if (usedGlasses.itemQueue.Count == 0)
            {
                if (Patron.NumOfGuests == 0 && Time.CurrentTime == 0)
                {
                    updateListBox("Allt klart, stänger nu puben", this); // If bar is empty and used glass queue is empty, this is written
                    while (Patron.NumOfGuests == 0 && Time.CurrentTime == 0) //Sleep loop to only write above statement once
                        Thread.Sleep(100);
                }
                else
                {
                    updateListBox("Väntar på disk", this);
                    while (!usedGlasses.itemQueue.Any())
                        Thread.Sleep(100);
                }
            }
        }

        public Waitress(int collectDuration, int washingDuration, int addToShelfDuration) : base()
        {
            CollectDuration = collectDuration; // sets duration of collection sleep timer
            WashingDuration = washingDuration; // sets duration of washing sleep timer
            AddToShelfDuration = addToShelfDuration; // sets duration of Adding to shelf sleep timer
        }

    }
}
