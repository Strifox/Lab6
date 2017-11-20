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
        private static int stayDuration;

        private static readonly Random Random = new Random();
        public static int CurrentNumOfGuests; // Ticker to count how many guests have entered and left

        // Properties
        public string Name { get; set; }

        public static int StayDuration
        {
            get { return stayDuration; }
            set { stayDuration = value; }
        }

        private readonly List<string> NamesList = new List<string>()
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

        // This method makes the behaviour of patron
        public void RunPatron(Action<string, object> logText)
        {
            LogText = logText;
            PatronEnters();
            while (!ChairQueue.Contains(this))
                Thread.Sleep(100);
            PatronLookingForChair();
            while (MainWindow.chairs.itemQueue.Count <= 0)
                Thread.Sleep(100);
            DrinksBeer();
            PatronLeaves();
        }

        private void PatronEnters()
        {
            CurrentNumOfGuests++;
            LogText?.Invoke($"{Name} enters the bar and walks up to the barqueue", this);
            Waiting(1);
            BarQueue.TryAdd(this);
        }

        public void PatronLookingForChair()
        {
            Waiting(3);
            LogText?.Invoke($"{Name} letar efter stol!", this);
            Waiting(4);
        }

        private void DrinksBeer()
        {
            LogText($"{Name} sitter ner och dricker öl!", this);
            MainWindow.chairs.itemQueue.Take();
            Waiting(stayDuration);
            MainWindow.usedGlasses.itemQueue.Add(new UsedGlass());

        }

        private void PatronLeaves()
        {
            LogText($"{Name} leaves the bar!", this);
            MainWindow.chairs.itemQueue.Add(new Chair());
            CurrentNumOfGuests--;
        }

        public Patron(int minTime, int maxTime)
        {
            Name = NamesList[Random.Next(NamesList.Count)];
            stayDuration = Random.Next(minTime, maxTime);
        }
    }

}
