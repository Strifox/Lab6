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
    public class Bartender : Agents
    {
        public void Handling(Items<Glass> glasses, Action<String, object> updateListBox)
        {
            //If statement to check if barqueue is empty
            if (BarQueue.Count == 0)
            {
                updateListBox($"Väntar på gäst", this); // updates bartenderlistbox with this statement if queue is empty.
                while (BarQueue.Count == 0)
                    Thread.Sleep(100);
            }

            //If statement to check if glass collection is empty
            if (glasses.GetNumOfItems() == 0)
            {
                updateListBox("waiting for glass", this); // updates bartenderlistbox with this statement if collection is empty.
                while (glasses.GetNumOfItems() == 0)
                    Thread.Sleep(100);
            }

            //if statement to check if barqueue and glass collection is not empty.
            if (BarQueue.Count > 0)
            {
                if (glasses.GetNumOfItems() > 0)
                {
                    updateListBox($"Plockar glas från hyllan", this); // updates bartenderlistbox with this statement if it is not empty
                    Thread.Sleep(3000);
                    glasses.itemQueue.Take();
                    Agents.ChairQueue.Add(Agents.BarQueue.First());
                    updateListBox($"Häller upp öl till {BarQueue.Take().Name}", this); // updates with this statement if glass collection is not empty. Also removes guest from Barqueue.
                    Thread.Sleep(3000);
                }
            }
        }

        public Bartender() : base()
        {
        }
    }
}
