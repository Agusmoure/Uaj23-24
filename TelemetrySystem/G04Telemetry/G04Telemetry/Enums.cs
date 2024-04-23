using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G04Telemetry
{
    public enum EventType : UInt32
    {
        SessionStart = 0,
        SessionStop = 1,
        GameStart = 2,
        GameEnd = 3,
        LevelStart = 4,
        LevelEnd = 5,
        Pause = 6,
        Resume = 7,
        //
        Attack = 8,
        EnemyReceive = 9,
        PlayerReceive = 10,
        PlayerDead = 11,
        RoomMove = 12,
    }
    public enum SerializeType : UInt32
    {
        JSON = 0
    }
    public enum PersistanceType : UInt32
    {
        File = 0
    }
    public enum LevelEnum : UInt32
    {
        None = 0,
        Level1=1,
        Level2=2
    }
    public enum LevelEnd : UInt32
    {
        Win=0,
        Loose=1,
        Other=2
    }
    public enum EnemyType : UInt32
    {
        Robot = 0,
        Spider = 1,
        Saw= 2,
        Sewer=3

    }
}
