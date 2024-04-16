using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G04Telemetry.CommonEvents
{
    internal class SessionStartEvent : BaseEvent
    {
       
        public SessionStartEvent(Tracker tracker, string gameName, Guid userID) : base((uint)EventID.SessionStart)
        {
            _data.Add("Game", gameName);

            _sessionID = Guid.NewGuid();
           // _data.Add("Session", _sessionID);
            _data["Session"] = _sessionID;
            tracker.setSessionID(_sessionID);
        }

    }
}
