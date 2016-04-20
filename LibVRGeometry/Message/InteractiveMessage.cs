using ProtoBuf;

namespace LibVRGeometry.Message
{
    [ProtoContract]
    public class InteractiveMessage
    {
        [ProtoMember(1)]
        public System.DateTime time;
    }
}
