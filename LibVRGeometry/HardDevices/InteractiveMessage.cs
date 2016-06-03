using ProtoBuf;

namespace LibVRGeometry
{
    [ProtoContract]
    public class InteractiveMessage 
    {
        [ProtoMember(1)]
        public System.DateTime time;
    }
}
