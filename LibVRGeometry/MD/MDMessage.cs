using ProtoBuf;

namespace LibVRGeometry
{
    /// <summary>
    /// 器械.
    /// </summary>
    [ProtoContract]
    public class MDMessage : UnitMessage
    {
        /// <summary>
        /// ID
        /// </summary>
        [ProtoMember(1)]
        public MDType type;


        /// <summary>
        /// 设备的移动速度 米/秒
        /// </summary>
        [ProtoMember(2)]
        public float move_speed;

        /// <summary>
        /// ID
        /// </summary>
        [ProtoMember(3)]
        public float rotate_speed;
    }
}
