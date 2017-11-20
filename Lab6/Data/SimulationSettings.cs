using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace Lab6
{
    public class SimulationSettings
    {
        // Numbers are in milliseconds except for SimulationTime (seconds)

        //Properties for Waitress class
        public static int CollectionDuration { get; set; } = 10000;
        public static int WashingDuration { get; set; } = 12000;
        public static int AddToShelfDuration { get; set; } = 3000;

        //Properties for Time class
        public static int SimulationSpeed { get; set; } = 1000;
        public static int SimulationTime { get; set; } = 300; // The timer for the pubs opening time

        public static int NumOfPatrons { get; set; } = 1;

    }
}
