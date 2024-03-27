using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G04Telemetry.CommonEvents;

namespace G04Telemetry.Serialization
{
    internal interface SerializationInterface
    {
        /// <summary>
        /// Se usa para abrir los datos que se desean usar 
        /// Ejemplo en json
        /// {
        /// </summary>
        /// <returns></returns>
        string startSerialize();

        /// <summary>
        /// Serializa el evento
        /// </summary>
        /// <param name="ev">Evento a serializar</param>
        /// <returns></returns>
        string serialize(BaseEvent ev);
        string serializeAll(ref Queue<BaseEvent> events);
        /// <summary>
        /// Se usa para cerrar los datos que se desean usar 
        /// Ejemplo en json
        /// }
        /// </summary>
        /// <returns></returns>
        string endSerialize();

        /// <summary>
        /// 
        /// </summary>
        /// <returns> El tipo de serializacion</returns>
        SerializeType getType();

        /// <returns>Formato del tipo de archivos .json,xml,etc.. </returns>
        string getExtension();

    }
}
