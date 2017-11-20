using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    public class Items<T> where T : class, new()
    {
        public T item;

        public BlockingCollection<T> itemQueue = new BlockingCollection<T>();

        public void CreateItems(T item, int count)
        {
            for (int i = 0; i < count; i++)
            {
                itemQueue.Add(new T());
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

        public Items() { item = new T(); }
    }
    public class Chair { public int maxNumOfChairs = 3; }

    public class Glass { public int maxNumOfGlasses = 20; }

    public class UsedGlass { public int maxNumOfUsedGlasses; }
}

