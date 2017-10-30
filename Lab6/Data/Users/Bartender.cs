using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Lab6
{
    public class Bartender : Agents
    {
        public BlockingCollection<string> behaviours = new BlockingCollection<string>()
        {
            "väntar i baren",
            "Plockar glas från hyllan",
            $"Häller upp öl till {?}"
        };
    }
}
