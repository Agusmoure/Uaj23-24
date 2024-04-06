using G04Telemetry.CommonEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G04Telemetry.SteamMazehemEvents
{
    public class PlayerReceiveDamageEvent:GameBaseEvent
    {
        public PlayerReceiveDamageEvent(float xPlayer, float yPlayer, float xEnemy,float yEnemy, EnemyType type) : base(((uint)EventID.PlayerReceive))
        {
            _data.Add("PlayerX", xPlayer);
            _data.Add("PlayerY", yPlayer);
            _data.Add("EnemyX", xEnemy);
            _data.Add("EnmeyY", yEnemy);
            _data.Add("EnemyType", type);
        }
    }
}
