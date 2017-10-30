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
using Lab6.Data;
using Lab6.Data.Users;

namespace Lab6.Data.Users
{
    public class Waitress : Agents
    {
        public BlockingCollection<string> behaviours = new BlockingCollection<string>()
        {
            $"Hittade {?} glas",
            "Hämtar glas från bord",
            $"Diskar glas och ställer i hyllan"
        };
    }
}
