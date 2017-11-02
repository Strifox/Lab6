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
    public abstract class Agents
    {
        public static ConcurrentQueue<Patron> BarQueue = new ConcurrentQueue<Patron>();
        public static ConcurrentQueue<Items> ChairQueue = new ConcurrentQueue<Items>();
        public static ConcurrentQueue<Items> GlassQueue = new ConcurrentQueue<Items>();
        public virtual BlockingCollection<string> Behaviours { get; set; }
        public static CancellationTokenSource cts = new CancellationTokenSource();
        public CancellationToken ct = cts.Token;


        public virtual string GetActions()
        {
            Console.WriteLine("Override this in inherited classes!");
            return "A specific action!";
        }
    }

}
