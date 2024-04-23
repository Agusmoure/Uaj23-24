using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G04Telemetry.CommonEvents
{
    public class GameBaseEvent : BaseEvent
    {
        Guid _gameSessionID;
        LevelEnum _level;
        public GameBaseEvent(uint eventID) : base(eventID)
        {
            _gameSessionID=Tracker.Instance().getGameSessionID();
            _level = Tracker.Instance().getLevel();
        }
    }
}
