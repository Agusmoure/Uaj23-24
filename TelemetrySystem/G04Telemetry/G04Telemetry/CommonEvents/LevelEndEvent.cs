using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G04Telemetry.CommonEvents
{
    internal class LevelEndEvent : BaseEvent
    {
        public LevelEndEvent(LevelEnum levelId, LevelEnd cause) : base((uint)EventType.LevelEnd) {
            _data.Add("LevelID", levelId);
            _data.Add("LevelEnd", cause);
        }
    }
}
