using ProtoBuf;

namespace LibVRGeometry
{
    /// <summary>
    /// 单位信息.
    /// </summary>
    [ProtoContract]
    public class UnitMessage
    {
        /// <summary>
        /// ID
        /// </summary>
        [ProtoMember(1)]
        public int id;

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
