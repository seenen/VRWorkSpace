using ProtoBuf;

namespace LibVRGeometry.Message
{
    /// <summary>
    /// 钛夹钳
    /// </summary>
    [ProtoContract]
    public class UM_MDTitaniumClamp : MDMessage
    {
        /// <summary>
        /// 控制在 float [0 - 1]之间
        /// </summary>
        [ProtoMember(1)]
        public float open_degree;

        /// <summary>
        /// 咬合的速度
        /// </summary>
        [ProtoMember(2)]
        public float merge_speed;
    }
}
