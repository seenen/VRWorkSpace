using ProtoBuf;
using System;

namespace LibVRGeometry
{
    /// <summary>
    /// 交互属性
    /// </summary>
    [Serializable]
    [Flags]
    public enum InteractiveType
    {
        /// <summary>
        /// 空类型
        /// </summary>
        [ProtoMember(1)]
        Null,

        /// <summary>
        /// 可穿透
        /// </summary>
        [ProtoMember(2)]
        Broken,

        /// <summary>
        /// 可阻挡
        /// </summary>
        [ProtoMember(2)]
        Block,


   }
}
