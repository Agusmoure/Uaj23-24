using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G04Telemetry.CommonEvents;
using Newtonsoft.Json;
namespace G04Telemetry.Serialization
{
    internal class JsonSerialize : SerializationInterface
    {
        private bool _firstTime=true;
        public string getExtension()
        {
            return ".json";
        }
        /// <summary>
        /// Serializa todos los eventos actuales
        /// CUIDADO esto borrara los eventos de la cola
        /// </summary>
        /// <param name="events"></param>
        /// <returns></returns>
        public string serializeAll(ref Queue<BaseEvent> events)
        {
            string all = _firstTime?"":",";
            _firstTime = false;
            while (events.Count > 0)
            {
                all += serialize(events.Dequeue());
                if (events.Count != 0)
                {
                    all += ",";
                }
            }
            return all;
        }

        public SerializeType getType()
        {
            return SerializeType.JSON;
        }

        public string startSerialize()
        {
            return "{\"data\":[";
        }

        public string endSerialize()
        {
            return "]}";
        }
        /// <summary>
        /// Serializa el evento que se le envia
        /// </summary>
        /// <param name="ev"></param>
        /// <returns></returns>
        public string serialize(BaseEvent ev)
        {
            return JsonConvert.SerializeObject(ev.getData(), Formatting.Indented);
        }
    }
}
