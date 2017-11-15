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
    public class Waitress : Agents
    {
        private int CollectDuration { get; set; }
        private int WashingDuration { get; set; }

        public void Handling(Items<UsedGlass> usedGlasses, Items<Chair> chairs, Action<string, object> updateListBox)
        {       // 9 glas, 8 chairs   10 sec hämta glas, 15 diska
            if (usedGlasses.itemQueue.Count > 0)
            {
                updateListBox("Picking up glasses", this);
                Thread.Sleep(CollectDuration);
                updateListBox("Cleaning glasses", this);
                Thread.Sleep(WashingDuration);
                foreach (var usedGlass in usedGlasses.itemQueue)
                {
                    usedGlasses.itemQueue.Take();
                    MainWindow.glasses.itemQueue.Add(new Glass());
                }
            }

            else
            {
                updateListBox("Waiting", this);
                while (!usedGlasses.itemQueue.Any())
                    Thread.Sleep(100);
            }
        }

        public Waitress(int collectDuration, int washingDuration) : base()
        {
             CollectDuration = collectDuration;
             WashingDuration = washingDuration;
        }

    }
}
