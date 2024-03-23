using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G04Telemetry
{
    public class Tracker
    {
        private Queue<BaseEvent> _events;
        private Guid _sessionID;
        private Guid _userId;
        private string _gameName;
        private static Tracker _instance;
        public static Tracker Instance()
        {
            return _instance;
        }
        public static bool Init(string gameName)
        {
            if (_instance != null) return false;
            _instance = new Tracker(gameName);
            return true;
        }
        private Tracker(string gameName)
        {
            _gameName = gameName;
            _userId = Guid.NewGuid();
            _events = new Queue<BaseEvent>();
            addEvent(new TrackerStartEvent());
        }
        public Guid getSessionID()
        {
            return _sessionID;
        }
        public void addEvent(BaseEvent e)
        {
            _events.Enqueue(e);
        }
        public BaseEvent removeEvent()
        {
            if (_events.Count > 0)
                return _events.Dequeue();
            else
                throw new Exception("No quedan elementos");
        }
        public int getNumberOFEvents()
        {
            return _events.Count;
        }
        public void setSessionID(Guid session)
        {
            _sessionID = session;
        }
        public Guid getUserID()
        {
            return _userId;
        }
        public void startSession()
        {
            addEvent(new SessionStartEvent(_gameName, _userId));
        }
        public void stopSession()
        {
            addEvent(new SessionEndEvent());
        }
        public void closeTracker()
        {
            addEvent(new TrackerEndEvent());
        }
        public Queue<BaseEvent> getEvents()
        {
            return _events;
        }
    }

}
