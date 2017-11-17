using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace Lab6.Data
{
    public static class SimulationSettings
    {
        //All numbers are in seconds

        //Waitress
        public static int CollectionDuration = 10000;
        public static int WashingDuration = 12000;
        public static int AddToShelfDuration = 3000;
        //Simulation
        public static int SimulationSpeed = 300;
    }
}
