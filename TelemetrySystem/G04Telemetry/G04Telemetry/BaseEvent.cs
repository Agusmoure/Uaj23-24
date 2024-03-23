using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G04Telemetry
{
    public class BaseEvent
    {
        public UInt32 _eventId;
        public long _timeStamp;

        public Dictionary<string, object> _data;
        public BaseEvent(UInt32 id) {
        _eventId = id;
            _timeStamp = _timeStamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds(); ;
           // _sessionID = Tracker.Instance().getSessionID();
            _data = new Dictionary<string, object>();
            _data.Add("eventId", id);
            _data.Add("timestamp", _timeStamp);
        }
        public UInt32 getIDEvent()
        {
            return _eventId;
        }
        public long getTimeStamp() { return _timeStamp;}
    }
}
