using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G04Telemetry.CommonEvents;
using G04Telemetry.Serialization;

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
        private SerializationInterface serialization;
        public static Tracker Instance()
        {
            return _instance;
        }
        /// <summary>
        /// Inicializa el tracker y añadel el evento de inicio de Tracker
        /// </summary>
        /// <param name="gameName">Nombre del juego que se va a trackear</param>
        /// <param name="timeToFlush">Tiempo entre envio y envio de datos</param>
        /// <returns></returns>
        public static bool Init(string gameName, float timeToFlush,SerializeType serializeType)
        {
            if (_instance != null) return false;
            _instance = new Tracker(gameName,timeToFlush,serializeType);
            return true;
        }

        private Tracker(string gameName, float timeToFlush,SerializeType serializeType)
        {
            _timeToFlush = timeToFlush;
            _gameName = gameName;
            _userId = Guid.NewGuid();
            switch (serializeType)
            {
                case SerializeType.JSON:
                    serialization = new JsonSerialize();
                    break;
                    default: throw new ArgumentException();
            }
            _events = new Queue<BaseEvent>();
            addEvent(new TrackerStartEvent());
        }
        public Guid getSessionID()
        {
            return _sessionID;
        }
        /// <summary>
        /// Añade el evento a la cola
        /// </summary>
        /// <param name="e"></param>
        public void addEvent(BaseEvent e)
        {
            _events.Enqueue(e);
        }
        /// <summary>
        /// Elimina el primer evento de la cola si puede si no lanza excepcion
        /// </summary>
        /// <returns>El evento que ha sido eliminado de la cola</returns>
        /// <exception cref="Exception"></exception>
        public BaseEvent removeEvent()
        {
            if (_events.Count > 0)
                return _events.Dequeue();
            else
                throw new Exception("No quedan elementos");
        }

        public void setSessionID(Guid session)
        {
            _sessionID = session;
        }
        public Guid getUserID()
        {
            return _userId;
        }
        #region Session
        /// <summary>
        /// Añade el evento de inicio de sesion
        /// </summary>
        public void startSession()
        {
            addEvent(new SessionStartEvent(_gameName, _userId));
        }
        /// <summary>
        /// Añade ek evento de fin de sesion
        /// </summary>
        public void endSession()
        {
            addEvent(new SessionEndEvent());
        }
        #endregion
        #region Game
        /// <summary>
        /// Añade el evento de comienzo de juego
        /// </summary>
        public void startGame()
        {
            addEvent(new GameStartEvent());
        }
        /// <summary>
        /// Añade el evento de final de juego
        /// </summary>
        public void endGame()
        {
            addEvent(new GameEndEvent());
        }
        #endregion
        #region level
        /// <summary>
        /// Añade el evento de inicio de nivel
        /// </summary>
        public void startLevel()
        {
            addEvent(new LevelStartEvent());
        }
        /// <summary>
        /// Añade el evento de fin de nivel
        /// </summary>
        public void endLevel()
        {
            addEvent(new LevelEndEvent());
        }
        #endregion
        #region pause
        /// <summary>
        /// Añade el evento de pausa
        /// </summary>
        public void pause()
        {
            addEvent(new PauseEvent());
        }
        /// <summary>
        /// Añade el evento de salir de pausa(resume)
        /// </summary>
        public void resume()
        {
            addEvent(new ResumeEvent()); 
        }
        #endregion
        /// <summary>
        /// Se añade el evento de cerrar el tracker y envia los elementos en la lista pendientes
        /// </summary>
        public void closeTracker()
        {
            addEvent(new TrackerEndEvent());
            //TODO hay que enviar los eventos restantes en la cola
        }

        public void update(float deltaTime)
        {
            _timer += deltaTime;
            Console.WriteLine(_timer);
            if( _timer > _timeToFlush)
            {
                Console.WriteLine("FLUSH");
                //TODO hay que enviar los eventos restantes en la cola
                _timer = 0;
            }

        }
        #region Test Functions
        public Queue<BaseEvent> getEvents()
        {
            return _events;
        }
        public int getNumberOFEvents()
        {
            return _events.Count;
        }
        public string getFirstEventSer()
        {
            return serialization.serialize(_events.Peek());
        }
        #endregion
    }

}
