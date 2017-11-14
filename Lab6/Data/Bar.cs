using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Lab6
{
    public class Bar
    {
        //Fields
        private int chairsInUse;

        //Private Properties
        private ConcurrentQueue<Patron> BarQueue { get; set; }
        private bool takeOrder { get { return BarQueue.Count > 0; } }

        //Public Properties
        public int TotalChairCount { get; set; }
        public int ChairsAvailableCount { get { return TotalChairCount - ChairsInUseCount; } }
        public int ChairsInUseCount { get { return chairsInUse; } set { chairsInUse = value; } }
        public bool CanTakeChair { get { return TotalChairCount > 0; } }
        public int guestsInBarQueue { get => BarQueue.Count; }

        //Simulation Speed
        private float TimeMultiplier = 1f;
        public int AdjustTimeToSimulationSpeed(int time)
        {
            return (int)(time * TimeMultiplier);
        }
        public Bar()
        {

        }

        #region Guest

        
        public bool IsGuestInBarQueue(Patron guest) { return BarQueue.Contains(guest); }
        public void AddGuestToBarQueue(Patron guest) { BarQueue.Enqueue(guest); }
        public Patron FirstInQueue()
        {
            while (!takeOrder)
            {
                Thread.Sleep(2000);
            }
            return BarQueue.First();
        }

        public void TakeChair()
        {
            ChairsInUseCount++;
        }

        public void ReturnChair()
        {
            if (ChairsAvailableCount != TotalChairCount)
                ChairsInUseCount--;
        }

        #endregion

    }
}
