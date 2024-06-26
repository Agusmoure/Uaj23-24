﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G04Telemetry.CommonEvents
{
    internal class LevelStartEvent : BaseEvent
    {
        public LevelStartEvent(LevelEnum levelId) : base((uint)EventType.LevelStart)
        {
            _data.Add("Level", levelId);
            Guid gameSessionID = Tracker.Instance().getGameSessionID();
            _data.Add("GameSession", gameSessionID);
        }
    }
}
