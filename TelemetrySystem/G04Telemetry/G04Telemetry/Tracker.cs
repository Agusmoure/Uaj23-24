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
        private float _timeToFlush;
        private float _timer;
        private static Tracker _instance;
        public static Tracker Instance()
        {
            return _instance;
        }
        /// <summary>
        /// Inicializa el tracker
        /// </summary>
        /// <param name="gameName">Nombre del juego que se va a trackear</param>
        /// <param name="timeToFlush">Tiempo entre envio y envio de datos</param>
        /// <returns></returns>
        public static bool Init(string gameName, float timeToFlush)
        {
            if (_instance != null) return false;
            _instance = new Tracker(gameName,timeToFlush);
            return true;
        }

        private Tracker(string gameName, float timeToFlush)
        {
            _timeToFlush = timeToFlush;
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
        public void update(float deltaTime)
        {
            _timer += deltaTime;
            Console.WriteLine(_timer);
            if( _timer > _timeToFlush)
            {
                Console.WriteLine("FLUSH");
                _timer = 0;
            }

        }
    }

}
