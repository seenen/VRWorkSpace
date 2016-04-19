using ProtoBuf;
using System;

namespace LibVRGeometry
{
    /// <summary>
    /// 数据格式
    /// </summary>
    [Serializable]
    [Flags]
    public enum VBOType
    {
        /// <summary>
        /// 没有定义格式 这是非法的
        /// </summary>
        [ProtoMember(1)]
        Null,

        /// <summary>
        /// 标准的.obj文件格式
        /// </summary>
        [ProtoMember(2)]
        DOT_OBJ,

        /// <summary>
        /// UNITY的MESH文件格式
        /// </summary>        
        [ProtoMember(3)]
        U3D_MESH,
    }
}
