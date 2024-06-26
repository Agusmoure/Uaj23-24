﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G04Telemetry.CommonEvents;
using G04Telemetry.Persistance;
using G04Telemetry.Serialization;

namespace G04Telemetry
{
    public class Tracker
    {
        private Guid _sessionID;
        private Guid _userId;
        private Guid _gameSessionID;
        private LevelEnum _level;
        private string _gameName;
        private float _timeToFlush;
        private float _timer;
        private static Tracker _instance;
        private SerializationInterface _serialization;
        private PersistanceBase _persistance;
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
        public static bool Init(string gameName, float timeToFlush,SerializeType serializeType,PersistanceType persistance, string filename="")
        {
            if (_instance != null) return false;
            _instance = new Tracker(gameName,timeToFlush);
            //Crea la id de sesion al generar el evento
            SessionStartEvent sE = new SessionStartEvent(_instance, gameName, _instance._userId);
            _instance.initSerialize(serializeType);
            string fn=filename+"_"+_instance._sessionID;
            //crea la cola de eventos ya que se guarda e el sistema de persistencia
            _instance.initPersistance(persistance,fn);
            //añade el evento despues de crear la cola
            _instance.startSession(sE);
            return true;
        }

        private Tracker(string gameName, float timeToFlush)
        {
            _timeToFlush = timeToFlush;
            _gameName = gameName;
            _userId = Guid.NewGuid();

        }
        private void initSerialize(SerializeType serializeType)
        {
            switch (serializeType)
            {
                case SerializeType.JSON:
                    _serialization = new JsonSerialize();
                    break;
                default: throw new ArgumentException();
            }
        }
        private void initPersistance(PersistanceType persistance,string filename)
        {
            switch (persistance)
            {
                case PersistanceType.File:
                    _persistance = new FilePersistance(filename, _serialization);
                    break;
                default: throw new ArgumentException();
            }
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
            _persistance.addEvent(e);
        }
        /// <summary>
        /// Elimina el primer evento de la cola si puede si no lanza excepcion
        /// </summary>
        /// <returns>El evento que ha sido eliminado de la cola</returns>
        /// <exception cref="Exception"></exception>
        public BaseEvent removeEvent()
        {
           return _persistance.removeEvent();
        }

        internal void setSessionID(Guid session)
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
        void startSession(SessionStartEvent sEvent)
        {
            addEvent(sEvent);
        }
        /// <summary>
        /// Añade el evento de fin de sesion
        /// </summary>
         void endSession()
        {
            addEvent(new SessionEndEvent());
            _persistance.flush();
            _persistance.close();
        }
        #endregion
        #region Game
        /// <summary>
        /// Añade el evento de comienzo de juego
        /// </summary>
        public void startGame()
        {
            _gameSessionID=Guid.NewGuid();
            addEvent(new GameStartEvent());
        }
        /// <summary>
        /// Añade el evento de final de juego
        /// </summary>
        public void endGame()
        {
            addEvent(new GameEndEvent());
            _gameSessionID = Guid.Empty;
        }
        internal Guid getGameSessionID() {
        return _gameSessionID;
        }
        #endregion
        #region level
        /// <summary>
        /// Añade el evento de inicio de nivel
        /// </summary>
        public void startLevel(LevelEnum levelID )
        {
            _level = levelID;
            addEvent(new LevelStartEvent(levelID));
        }
        /// <summary>
        /// Añade el evento de fin de nivel
        /// </summary>
        public void endLevel(LevelEnum levelID,LevelEnd cause)
        {
            addEvent(new LevelEndEvent(levelID,cause));
            _level = LevelEnum.None;
        }
        internal LevelEnum getLevel()
        {
            return _level;
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
           endSession();

        }

        public void update(float deltaTime)
        {
            _timer += deltaTime;
            Console.WriteLine(_timer);
            if( _timer > _timeToFlush)
            {
                _persistance.flush();
                _timer = 0;
            }

        }

        internal SerializationInterface getSerialization() { return _serialization; }
    }

}
