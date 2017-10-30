using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Lab6
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
