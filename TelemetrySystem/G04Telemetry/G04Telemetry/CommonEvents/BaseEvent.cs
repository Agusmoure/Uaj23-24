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
        protected Guid _sessionID;
        protected Guid _userID;
        protected Dictionary<string, object> _data;
        public BaseEvent(uint id)
        {
            _eventId = id;
            _timeStamp = _timeStamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            _data = new Dictionary<string, object>();
            _sessionID = Tracker.Instance().getSessionID();
            _userID = Tracker.Instance().getUserID();
            _data.Add("eventId", id);
            _data.Add("timestamp", _timeStamp);
            //Datos que deben compartir todos los eventos siempre y cuando existan
            _data.Add("Session", _sessionID);
            _data.Add("User", _userID);

        }
        public uint getIDEvent()
        {
            return _eventId;
        }
        public long getTimeStamp() { return _timeStamp; }
        public Dictionary<string, object> getData() { return _data; }
    }
}
