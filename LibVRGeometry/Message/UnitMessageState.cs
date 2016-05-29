using ProtoBuf;
using System;

namespace LibVRGeometry
{
    /// <summary>
    /// Mesh的消息类型
    /// </summary>
    [Serializable]
    [Flags]
    public enum UnitMessageState
    {
        /// <summary>
        /// 空
        /// </summary>
        [ProtoMember(1)]
        Null,

        /// <summary>
        /// 新建一个Mesh
        /// </summary>
        [ProtoMember(2)]
        Create,

        /// <summary>
        /// 刷新Mesh
        /// </summary>
        [ProtoMember(3)]
        Modify,

        /// <summary>
        /// 删除Mesh
        /// </summary>
        [ProtoMember(4)]
        Destory,
    }
}
