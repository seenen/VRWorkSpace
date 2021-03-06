﻿using ProtoBuf;
using System;

namespace LibVRGeometry
{
    /// <summary>
    /// 医学器材类型
    /// </summary>
    [Serializable]
    [Flags]
    public enum HDType
    {
        /// <summary>
        /// 空类型
        /// </summary>
        [ProtoMember(1)]
        Null,

        /// <summary>
        /// 钛夹
        /// </summary>
        [ProtoMember(2)]
        TitaniumClamp,

        /// <summary>
        /// 剪刀
        /// </summary>
        [ProtoMember(3)]
        Scissors,

        /// <summary>
        /// 机械手臂
        /// </summary>
        [ProtoMember(4)]
        RobotArm,
    }
}
