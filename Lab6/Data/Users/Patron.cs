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
    public class Patron : Agents
    {
        //Delegates
        private Action<string> LogText { get; set; }

        // Fields
        private readonly Random _random = new Random();

        // Class (static) Fields
        public static int numOfGuests = 0;

        // Propertys
        public string Name { get; set; }


        private readonly List<string> _namesList = new List<string>()
        {
            "Andreas",
            "Erik",
            "Johan",
            "Magnus",
            "Olle",
            "Peter",
            "Daniel",
            "Matthias",
            "Johannes",
            "Robert",
            "Erica",
            "Matilda",
            "Sofia",
            "Rebecka",
            "Eva",
            "Linnea",
            "Anna",
            "Johanna",
            "Amanda",
            "Jennie"
        };

        public void PatronEnters(Action<string> logText)
        {
            LogText = logText;
            logText?.Invoke($"{Name} enters the bar and walks up to the barqueue");
            Thread.Sleep(1);
            Agents.BarQueue.TryAdd(this);
        }

        public void PatronBeer(Action<string> logText)
        {
            Agents.BarQueue.Take();
            logText?.Invoke($"{Name} takes his beer from bartender");
            //Items.ChairQueue.TryAdd(new Chair());
        }

        public void PatronChair(Action<string> logText)
        {
            LogText = logText;
            logText?.Invoke($"{Name} waiting for an empty chair");
        }

        public void PatronDrinks(Action<string> logText)
        {
            LogText = logText;
            logText?.Invoke($"{Name} sits down and drinks his beer");
        }

        public void PatronLeaves(Action<string> logText)
        {
            LogText = logText;
            logText?.Invoke($"{Name} has finished drinking and is now leaving the bar");
        }

        public Patron()
        {
            Name = _namesList[_random.Next(_namesList.Count)];
            numOfGuests += 1;
        }

    }
}


