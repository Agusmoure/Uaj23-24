using G04Telemetry.CommonEvents;
using G04Telemetry.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G04Telemetry.Persistance
{
    internal abstract class PersistanceBase
    {
        protected Queue<BaseEvent> _events;
        protected SerializationInterface _serializationInterface;
        protected PersistanceBase(SerializationInterface serialization)
        {
            _events = new Queue<BaseEvent>();
            _serializationInterface = serialization;
        }
        /// <summary>
        ///  Añade el evento a la cola
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
        public abstract void flush();

        public abstract void close();
        #region test
        public int eventCount()
        {
            return _events.Count;
        }
        #endregion
    }
}
