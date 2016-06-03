using ProtoBuf;

namespace LibVRGeometry
{
    /// <summary>
    /// 器械.
    /// </summary>
    [ProtoContract]
    [ProtoInclude(4, typeof(HDScissorsMessage))]
    [ProtoInclude(5, typeof(HDTitaniumClampMessage))]
    [ProtoInclude(6, typeof(HDRobotArmMessage))]
    public class HDMessage : UnitMessage
    {
        /// <summary>
        /// ID
        /// </summary>
        [ProtoMember(1)]
        public HDType type;


        /// <summary>
        /// 设备的移动速度 米/秒
        /// </summary>
        [ProtoMember(2)]
        public float move_speed;

        /// <summary>
        /// 旋转速率
        /// </summary>
        [ProtoMember(3)]
        public float rotate_speed;
    }
}
