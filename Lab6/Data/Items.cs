using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    public class Items<T>
    {
        public BlockingCollection<T> itemQueue = new BlockingCollection<T>();

        public void CreateItems(T item, int count)
        {            
            for(int i = 0; i < count; i++)
            {
                itemQueue.Add(item);
            }
        }

        public int GetNumOfItems()
        {
            int n = 0;
            for (int i = 1; i <= itemQueue.Count; i++)
            {
                n++;
            }
            return n;
        }

    }
    public class Chair : Items<Chair>
    {
       // public int numOfChairs = 9;  
    }

    public class Glass : Items<Glass>
    {
       // public int numOfGlasses = 8;
    }
}

