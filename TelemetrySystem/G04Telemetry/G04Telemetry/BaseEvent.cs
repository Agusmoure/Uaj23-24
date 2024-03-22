using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G04Telemetry
{
    public class BaseEvent
    {
        public Int32 _eventId;
        public long _timeStamp;
        public Guid _sessionID;

        public Dictionary<string, object> _data;
        public BaseEvent(Int32 id) {
        _eventId = id;
            _timeStamp = _timeStamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds(); ;
            _sessionID = Tracker.Instance().getSessionID();
            _data = new Dictionary<string, object>();
            _data.Add("eventId", id);
            _data.Add("timestamp", _timeStamp);
            _data.Add("session",_sessionID.ToString());
        }
        public Int32 getIDEvent()
        {
            return _eventId;
        }
        public long getTimeStamp() { return _timeStamp;}
    }
}
