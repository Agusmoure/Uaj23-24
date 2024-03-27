using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G04Telemetry
{
    internal class LevelEndEvent:BaseEvent
    {
        public LevelEndEvent() : base(((uint)EventID.LevelEnd)) { }
    }
}
