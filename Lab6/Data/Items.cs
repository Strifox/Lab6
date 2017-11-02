using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    public class Items
    {

        public static void CreateItems()
        {
            int antalChairs = 100;
            int antalGlass = 100;
            
            for(int i = 0; i < antalGlass; i++)
            {
                GlassQueue.Add(new Glass());
            }
            for (int i = 0; i < antalChairs; i++)
            {
                ChairQueue.Add(new Chair());
            }
        }

        public static BlockingCollection<Chair> ChairQueue = new BlockingCollection<Chair>();
        

        public static BlockingCollection<Glass> GlassQueue = new BlockingCollection<Glass>();
    }

    public class Chair : Items
    {
       // public int numOfChairs = 9;  
    }

    public class Glass : Items
    {
       // public int numOfGlasses = 8;
    }
}

