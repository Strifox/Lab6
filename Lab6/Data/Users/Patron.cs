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
using Lab6.Data;
using Lab6.Data.Users;

namespace Lab6.Data.Users
{
    public class Patron : Agents
    {
        // Class (static) Fields
        public static int numOfGuests = 0;

        // Propertys
        public string Name { get; set; }
        public override BlockingCollection<string> Behaviours { get; set; }

        // Lists / Collections
        private List<string> namesList = new List<string>()
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

        // Methods

        public override string GetActions()
        {
            Behaviours = new BlockingCollection<string>()
            {
                $"{Name} kommer in och går till baren",
                $"{Name}Väntar på servering",
                $"{Name} letar efter stol",
                $"{Name} sitter och dricker öl",
                $"{Name} har druckit upp och lämnar baren"
            };
            return Behaviours.Take();
        }

        public string GenerateRandomName()
        {
            Random random = new Random();

            string name = namesList[random.Next(namesList.Count())];
            return name;
        }

        public Patron() : base()
        {
            numOfGuests++;
            Name = GenerateRandomName();
        }
    }
}
