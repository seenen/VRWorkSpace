using ProtoBuf;

namespace LibVRGeometry.Message
{
    [ProtoContract]
    public class EditorMessage
    {
        [ProtoMember(1)]
        public System.DateTime st;

        [ProtoMember(2)]
        public string name = string.Empty;

        [ProtoBuf.ProtoMember(3)]
        public string age = "0";
    }
}
