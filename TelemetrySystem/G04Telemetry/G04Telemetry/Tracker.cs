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
        private static Tracker _instance;
        public static Tracker Instance()
        {
            return _instance;
        }
        public static bool Init()
        {
            if (_instance != null) return false;
            _instance = new Tracker();
            return true;
        }
        private Tracker()
        {
            _events = new Queue<BaseEvent>();
            _sessionID = Guid.NewGuid();
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
    }
}
