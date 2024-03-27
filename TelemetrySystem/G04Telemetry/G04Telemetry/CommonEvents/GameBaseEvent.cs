using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G04Telemetry.CommonEvents
{
    internal class GameBaseEvent : BaseEvent
    {
        Guid _sessionID;
        Guid _userID;
        public GameBaseEvent(uint eventID) : base(eventID)
        {
            _sessionID = Tracker.Instance().getSessionID();
            _userID = Tracker.Instance().getUserID();
            _data.Add("Session", _sessionID);
            _data.Add("User", _userID);
        }
    }
}
