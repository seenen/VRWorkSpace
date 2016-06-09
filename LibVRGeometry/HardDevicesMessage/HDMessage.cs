﻿using ProtoBuf;

namespace LibVRGeometry
{
    /// <summary>
    /// 器械.
    /// </summary>
    [ProtoContract]
    [ProtoInclude(6, typeof(HDScissorsMessage))]
    [ProtoInclude(7, typeof(HDTitaniumClampMessage))]
    [ProtoInclude(8, typeof(HDRobotArmMessage))]
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

        /// <summary>
        /// 长度
        /// </summary>
        [ProtoMember(4)]
        public float length;

        /// <summary>
        /// 宽度
        /// </summary>
        [ProtoMember(5)]
        public float width;
    }
}