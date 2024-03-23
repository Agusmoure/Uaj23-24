using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G04Telemetry
{
    public class SessionStartEvent:BaseEvent
    {
        Guid _session;
        public SessionStartEvent(string gameName, Guid userID):base(((uint)EventID.SessionStart))
        {
            _data.Add("Game", gameName);
            _data.Add("UserID", userID);
            _session= Guid.NewGuid();
            Tracker.Instance().setSessionID(_session);
        }

    }
}
