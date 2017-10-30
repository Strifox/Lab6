using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Lab6
{
    public class Patron : Agents
    {
        // Fields
        public string Name { get; set;}
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

        public string Names()
        {
            Random random = new Random();

            var name = namesList[random.Next(namesList.Count())];
            return name;
        }

        public Patron()
        {
            Name = Names();
        }
    }
}
