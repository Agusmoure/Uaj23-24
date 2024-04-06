using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G04Telemetry.CommonEvents
{
    internal class LevelStartEvent<T> : BaseEvent
    {
        public LevelStartEvent(T levelId) : base((uint)EventID.LevelStart)
        {
            _data.Add("LevelID", levelId);
        }
    }
}
