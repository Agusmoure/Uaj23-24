using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G04Telemetry
{
    internal class GameEndEvent:BaseEvent
    {
        public GameEndEvent() : base(((uint)EventID.GameEnd))
        {

        }
    }
}
