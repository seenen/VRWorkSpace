using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace LibVRGeometry
{
    [Serializable]
    [ProtoContract]
    public class MessageHead
    {

        [ProtoMember(1)]
        public Object o;
    }
}
