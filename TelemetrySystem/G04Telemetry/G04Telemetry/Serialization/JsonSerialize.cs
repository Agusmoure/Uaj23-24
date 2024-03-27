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
        public string getExtension()
        {
            return ".json";
        }
        /// <summary>
        /// Serializa el data del evento que recibe
        /// </summary>
        /// <param name="ev"></param>
        /// <returns></returns>
        public string serialize(BaseEvent ev)
        {
            return JsonConvert.SerializeObject(ev.getData(), Formatting.Indented);
        }

        public SerializeType getType()
        {
            return SerializeType.JSON;
        }
    }
}
