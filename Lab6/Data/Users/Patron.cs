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
        private Action<string, object> LogText { get; set; }

        // Fields
        private static readonly Random _random = new Random();

        // Class (static) Fields
        public static int numOfGuests;

        // Properties
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

        public void RunPatron(Action<string, object> logText)
        {
            LogText = logText;
            PatronEnters();
            while (!ChairQueue.Contains(this))
                Waiting(100);
            PatronLookingForChair();
            while (MainWindow.chairs.ItemQueue.Count <= 0)
                Waiting(100);
            DrinksBeer();
            PatronLeaves();
        }
        private void PatronEnters()
        {
            numOfGuests++;
            LogText?.Invoke($"{Name} enters the bar and walks up to the barqueue", this);
            Thread.Sleep(1000);
            Agents.BarQueue.TryAdd(this);
        }
        public void PatronLookingForChair()
        {
            Thread.Sleep(3000);
            LogText?.Invoke($"{Name} letar efter stol!", this);
            Thread.Sleep(4000);
        }
        private void DrinksBeer()
        {
            LogText($"{Name} sitter ner och dricker öl!", this);
            MainWindow.chairs.ItemQueue.Take();
            Thread.Sleep(_random.Next(10000, 20000));
            MainWindow.usedGlasses.ItemQueue.Add(new UsedGlass());

        }
        private void PatronLeaves()
        {
            LogText($"{Name} leaves the bar!", this);
            MainWindow.chairs.ItemQueue.Add(new Chair());
            numOfGuests--;
        }
        private void Waiting(int time)
        {
            Thread.Sleep(time);
        }
        public Patron()
        {
            Name = _namesList[_random.Next(_namesList.Count)];
        }
    }

}



