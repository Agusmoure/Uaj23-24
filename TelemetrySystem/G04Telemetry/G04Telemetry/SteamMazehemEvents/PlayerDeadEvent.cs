using G04Telemetry.CommonEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G04Telemetry.SteamMazehemEvents
{
    public class PlayerDeadEvent:GameBaseEvent
    {
        public PlayerDeadEvent(float x, float y): base(((uint) EventID.PlayerDead))
        {
            _data.Add("PlayerX", x);
            _data.Add("PlayerY", y);
        }
}
}
