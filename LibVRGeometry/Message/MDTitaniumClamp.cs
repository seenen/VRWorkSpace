using ProtoBuf;

namespace LibVRGeometry.Message
{
    /// <summary>
    /// 钛夹钳
    /// </summary>
    [ProtoContract]
    public class MDTitaniumClamp : UnitMessage
    {
        /// <summary>
        /// 控制在 float [0 - 1]之间
        /// </summary>
        [ProtoMember(1)]
        public float open_degree;
    }
}
