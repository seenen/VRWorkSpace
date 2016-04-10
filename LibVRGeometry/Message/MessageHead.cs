using ProtoBuf;
using System;

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
