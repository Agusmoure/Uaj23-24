using G04Telemetry.CommonEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G04Telemetry.SteamMazehemEvents
{
    public class AttackEvent:GameBaseEvent
    {
        public AttackEvent(float x, float y) : base(((uint)EventID.Attack))
        {
            _data.Add("PlayerX", x);
            _data.Add("PlayerY", y);
        }
    }
}
