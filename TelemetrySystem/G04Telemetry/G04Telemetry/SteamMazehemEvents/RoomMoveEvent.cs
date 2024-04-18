using G04Telemetry.CommonEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G04Telemetry.SteamMazehemEvents
{
    public class RoomMoveEvent: GameBaseEvent
    {
        public RoomMoveEvent() : base(((uint)EventType.RoomMove))
        {

        }
    }
}
