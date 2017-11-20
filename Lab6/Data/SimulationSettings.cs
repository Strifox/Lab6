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
        private SimulationSettings()
        {

        }
        // All Property numbers are in seconds

        //Private Fields
        //Time
        private int simulationSpeed = 1;
        private int simulationTime = 120; // The timer for the pubs opening time
        //Waitress
        private int collectionDurationWaitress = 10;
        private int washingDurationWaitress = 12;
        private int addToShelfDurationWaitress = 3;
        //Bouncer
        private int numOfPatrons = 1;
        private int minimumStayDurationPatron = 10;
        private int maximumStayDurationPatron = 20;
        private bool createBussLoadOfPatrons = false; // Creates 15 patrons after 20 seconds if set to true
        //Items
        private int maxNumOfChairs = 9;
        private int maxNumOfGlasses = 8;
        private int maxNumOfUsedGlasses;

        //Properties
        //Waitress
        public int CollectionDurationWaitress { get { return collectionDurationWaitress; } set { collectionDurationWaitress = value; } }
        public int WashingDurationWaitress { get { return washingDurationWaitress; } set { washingDurationWaitress = value; } }
        public int AddToShelfDurationWaitress { get { return addToShelfDurationWaitress; } set { addToShelfDurationWaitress = value; } }
        //Bouncer
        public int NumOfPatrons { get { return numOfPatrons; } set { numOfPatrons = value; } }
        public int MinimumStayDurationPatron { get { return minimumStayDurationPatron; } set { minimumStayDurationPatron = value; } }
        public int MaximumStayDurationPatron { get { return maximumStayDurationPatron; } set { maximumStayDurationPatron = value; } }
        public bool CreateBussLoadOfPatrons { get { return createBussLoadOfPatrons; } set { createBussLoadOfPatrons = value; } }
        //Items
        public int MaxNumOfChairs { get { return maxNumOfChairs; } set { maxNumOfChairs = value; } }
        public int MaxNumOfGlasses { get { return maxNumOfGlasses; } set { maxNumOfGlasses = value; } }
        public int MaxnNumOfUsedGlasses { get { return maxNumOfUsedGlasses; } set { maxNumOfUsedGlasses = value; } }
        //Time
        public int SimulationSpeed { get { return simulationSpeed; } set { simulationSpeed = value; } }
        public int SimulationTime { get { return simulationTime; } set { simulationTime = value; } }


        private static SimulationSettings instance = new SimulationSettings();

        public static SimulationSettings MySimulation()
        {
            return instance;
        }

    }
}
