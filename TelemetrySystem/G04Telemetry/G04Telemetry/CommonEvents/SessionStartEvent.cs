using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G04Telemetry.CommonEvents
{
    internal class SessionStartEvent : BaseEvent
    {
        Guid _session;
        public SessionStartEvent(Tracker tracker, string gameName, Guid userID) : base((uint)EventID.SessionStart)
        {
            _data.Add("Game", gameName);

            _session = Guid.NewGuid();

            tracker.setSessionID(_session);
        }

    }
}
