using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G04Telemetry.CommonEvents
{
    public class BaseEvent
    {
        protected uint _eventId;
        protected long _timeStamp;

        protected Dictionary<string, object> _data;
        public BaseEvent(uint id)
        {
            _eventId = id;
            _timeStamp = _timeStamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds(); ;
            // _sessionID = Tracker.Instance().getSessionID();
            _data = new Dictionary<string, object>();
            _data.Add("eventId", id);
            _data.Add("timestamp", _timeStamp);
        }
        public uint getIDEvent()
        {
            return _eventId;
        }
        public long getTimeStamp() { return _timeStamp; }
        public Dictionary<string, object> getData() { return _data; }
    }
}
