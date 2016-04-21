using ProtoBuf;

namespace LibVRGeometry.Message
{
    /// <summary>
    /// 剪刀
    /// </summary>
    [ProtoContract]
    public class UM_MDScissors : MDMessage
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

    /// <summary>
    /// 钛夹钳状态
    /// </summary>
    [ProtoContract]
    public class IM_MD2HO : InteractiveMessage
    {
        /// <summary>
        /// 医疗设备ID
        /// </summary>
        [ProtoMember(1)]
        public int MD_ID;

        /// <summary>
        /// 器官ID
        /// </summary>
        [ProtoMember(2)]
        public int HO_ID;

        /// <summary>
        /// 是否有刃
        /// </summary>
        [ProtoMember(3)]
        public bool Blade;

        /// <summary>
        /// 位置
        /// </summary>
        [ProtoMember(4)]
        public _Vector3 Pos;
    }
}
