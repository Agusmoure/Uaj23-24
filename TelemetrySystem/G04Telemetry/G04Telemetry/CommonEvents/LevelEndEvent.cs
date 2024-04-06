using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G04Telemetry.CommonEvents
{
    internal class LevelEndEvent : BaseEvent
    {
        public LevelEndEvent(LevelEnum levelId) : base((uint)EventID.LevelEnd) {
            _data.Add("LevelID", levelId);

        }
    }
}
