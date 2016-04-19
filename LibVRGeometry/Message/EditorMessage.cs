using ProtoBuf;

namespace LibVRGeometry.Message
{
    /// <summary>
    /// 编辑器信息
    /// </summary>
    [ProtoContract]
    public class EditorMessage
    {
        [ProtoMember(1)]
        public System.DateTime st;

        [ProtoMember(2)]
        public string name = string.Empty;

        [ProtoMember(3)]
        public string age = "0";
    }
}
