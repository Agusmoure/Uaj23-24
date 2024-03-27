using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G04Telemetry.CommonEvents
{
    internal class GameStartEvent : BaseEvent
    {
        public GameStartEvent() : base((uint)EventID.GameStart)
        {

        }

    }
}
