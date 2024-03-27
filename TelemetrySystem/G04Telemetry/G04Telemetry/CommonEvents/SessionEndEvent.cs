using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G04Telemetry.CommonEvents
{
    internal class SessionEndEvent : BaseEvent
    {
        Guid _sessionId;
        public SessionEndEvent() : base((uint)EventID.SessionStop)
        {
            _sessionId = Tracker.Instance().getSessionID();
            _data.Add("Session", _sessionId);
        }
    }
}
