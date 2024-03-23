using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G04Telemetry
{
    public enum EventID:UInt32
    {
        TrackerInitialize = 0,
        TrackerEnd = 1,
        SessionStart= 2,
        SessionStop= 3,
    }
}
