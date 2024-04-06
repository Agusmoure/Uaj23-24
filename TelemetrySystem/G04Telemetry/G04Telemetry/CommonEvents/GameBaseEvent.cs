using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G04Telemetry.CommonEvents
{
    public class GameBaseEvent : BaseEvent
    {

        public GameBaseEvent(uint eventID) : base(eventID)
        {
            //Duda preguntar lo de la id del evento unico porque quizas con el timestamp ya sirve


        }
    }
}
