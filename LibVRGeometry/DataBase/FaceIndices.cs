using ProtoBuf;
using System;

namespace LibVRGeometry
{
    /// <summary>
    /// 一个三角面对应的顶点 UV和Normal索引
    /// </summary>
    [Serializable]
    [ProtoContract]
    public struct FaceIndices
    {
        /// <summary>
        /// 顶点索引号
        /// </summary>
        [ProtoBuf.ProtoMember(1)]
        public int vi;

        /// <summary>
        /// UV索引号
        /// </summary>
        [ProtoBuf.ProtoMember(2)]
        public int vu;

        /// <summary>
        /// 法线索引号
        /// </summary>
        [ProtoMember(3)]
        public int vn;
    }

}
