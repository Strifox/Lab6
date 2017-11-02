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
        public override BlockingCollection<string> Behaviours { get; set; }

        public override string GetActions()
        {
            Behaviours = new BlockingCollection<string>()
            {
                "väntar i baren",
                "Plockar glas från hyllan",
                $"Häller upp öl till ?"
            };
            return Behaviours.Take();   
        }

        public Bartender() : base()
        {
            GetActions();
        }
    }
}
