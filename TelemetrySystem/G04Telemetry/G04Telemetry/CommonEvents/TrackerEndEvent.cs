﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G04Telemetry.CommonEvents
{
    internal class TrackerEndEvent : BaseEvent
    {
        public TrackerEndEvent() : base((uint)EventID.TrackerEnd)
        {

        }
    }
}