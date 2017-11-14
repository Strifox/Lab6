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
            if (BarQueue.Count == 0)
                updateListBox($"Väntar på gäst", this);
            while (BarQueue.Count == 0)
                Thread.Sleep(100);
            if (BarQueue.Count > 0)
            {
                if (glasses.GetNumOfItems() > 0)
                {

                    updateListBox($"Plockar glas från hyllan", this);
                    glasses.itemQueue.Take();
                    Thread.Sleep(3000);

                    Agents.ChairQueue.Add(Agents.BarQueue.First());
                    updateListBox($"Häller upp öl till {BarQueue.Take().Name}", this);
                    Thread.Sleep(3000);
                }
            }
        }

        public Bartender() : base()
        {
        }
    }
}
