using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G04Telemetry
{
    public enum EventID : UInt32
    {
        SessionStart = 0,
        SessionStop = 1,
        GameStart = 2,
        GameEnd = 3,
        LevelStart = 4,
        LevelEnd = 5,
        Pause = 6,
        Resume = 7
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
        Level1=0,
        Level2=1
    }
}
