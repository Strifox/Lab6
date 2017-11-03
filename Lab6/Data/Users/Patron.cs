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
        // Fields
        public static int NumOfGuests = 0;
        private readonly Random _random = new Random();

        // Properties
        public string Name { get; set; }
        private Action<string> LogText { get; set; }
        private bool GotDrink = false;
        private bool IsSitting = false;
        private bool IsDrinking = false;

        // Inherited abstract properties
        public override Action Behaviour { get; set; }
        public override Bar BarStatus { get; set; }
        public override bool IsActive { get; set; }
        public override void Deactive()
        {
            GotDrink = false;
            IsSitting = false;
            IsDrinking = false;
            base.Deactive();
        }

        //BlockingCollection<string> behaviours { get; set; }
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

        public void RunPatron(Action<string> logText)
        {
            Behaviour = () =>
            {
                if (GotDrink && !BarStatus.IsGuestInQueue(this))
                {
                    BarStatus.AddGuestToQueue(this);
                    PatronEnters(LogText);
                }
                while (!GotDrink)
                {
                    Thread.Sleep(200);
                }
                if (GotDrink && !IsSitting)
                {
                    PatronTakesBeerAndWaitForChair(LogText);
                    while (!BarStatus.CanTakeChair)
                    {
                        Thread.Sleep(200);
                    }
                    PatronChair(LogText);
                    BarStatus.TakeChair();
                    IsSitting = true;
                }
                if (GotDrink && IsSitting)
                {
                    PatronDrinks(LogText);
                    PatronLeaves(LogText);
                    BarStatus.ReturnChair();
                    Deactive();
                }
            };
        }
        public void PatronEnters(Action<string> logText)
        {
            LogText = logText;
            Name = _namesList[_random.Next(_namesList.Count)];
            logText?.Invoke($"{Name} enters the bar and walks up to the barqueue\nThere are {BarStatus.guestsInBarQueue} people in queue");
            Thread.Sleep(1000);
        }

        public void PatronTakesBeerAndWaitForChair(Action<string> logText)
        {
            LogText = logText;
            logText?.Invoke($"{Name} takes the beer from bartender and waits for an empty chair");
        }

        public void PatronChair(Action<string> logText)
        {
            LogText = logText;
            logText?.Invoke($"{Name} sits down on a chair");
            Thread.Sleep(4000);
        }

        public void PatronDrinks(Action<string> logText)
        {
            LogText = logText;
            logText?.Invoke($"{Name}drinks his beer");
            Thread.Sleep(_random.Next(10000, 20000));
        }

        public void PatronLeaves(Action<string> logText)
        {
            LogText = logText;
            logText?.Invoke($"{Name} has finished drinking and is now leaving the bar");

        }

        public Patron(Action<string> logText)
        {
            LogText = logText;
            RunPatron(logText);
        }

    }
}


