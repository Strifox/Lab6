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
        // Class (static) Fields
        public static int NumOfGuests = 0;

        // Propertys
        public string Name { get; set; }

        private readonly Random _random = new Random();

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

        private void PatronEnter(Action<string> logText)
        {
            LogText = logText;
            Name = _namesList[_random.Next(_namesList.Count)];
            logText?.Invoke($"{Name} Enter the bar and walks up to bar");
        }

        private void PatronDrink(Action<string> logText)
        {
            LogText = logText;
            logText?.Invoke($"{Name} sits down and drinks his beer");
        }

        public Patron(Action<string> logText)
        {
            if (Time.Increment < 12)
                PatronEnter(logText);
            else
                PatronDrink(logText);
        }
    }
}


//public string Behaviours()
//{
//    behaviours = new BlockingCollection<string>()
//    {
//        $"{Name} kommer in och går till baren",
//        $"{Name}Väntar på servering",
//        $"{Name} letar efter stol",
//        $"{Name} sitter och dricker öl",
//        $"{Name} har druckit upp och lämnar baren"
//    };
//    return behaviours.Take();
//}

        //public string Names()
        //{
        //    Random random = new Random();
        //    var name = namesList[random.Next(namesList.Count())];
        //    return name;
        //}

//        public Patron()
//        {
//            Random random = new Random();
//            Name = namesList[random.Next(namesList.Count)];
//        }

//        public void Action(Action<string> logText)
//        {
//            numOfGuests += 1;
//            if (Time.Increment < 120)
//            {   
//                LogText = logText;
//                logText?.Invoke($"{Name} entered the bar");
//            }
//        }
//    }
//}
