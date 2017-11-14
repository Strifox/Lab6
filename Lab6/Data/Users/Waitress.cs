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

        public Waitress() : base()
        {
        }
        public void Handling(Items<UsedGlass> usedGlasses, Items<Chair> chairs, Action<string, object> updateListBox)
        {       // 9 glas, 8 chairs   10 sec hämta glas, 15 diska
            if (usedGlasses.itemQueue.Count >= 4)
            {
                updateListBox("Picking up glasses", this);
                Thread.Sleep(10000);
                updateListBox("Cleaning glasses", this);
                Thread.Sleep(15000);

                for (int i = 0; i < 4; i++)
                {
                    MainWindow.glasses.itemQueue.Add(new Glass());
                }
                {

                }
            }

        }
    }
}
