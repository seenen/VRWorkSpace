using ProtoBuf;
using System;
using System.Collections.Generic;

namespace LibVRGeometry
{
    /// <summary>
    /// 单个物体数据 这里的数据格式是根据一个标准的 .obj得来
    /// </summary>
    [Serializable]
    [ProtoContract]
    public class VBOBufferSingle
    {
        /// <summary>
        /// 模型id 全局唯一id号
        /// </summary>
        [ProtoMember(1)]
        public int id { get; set; }

        /// <summary>
        /// 模型刷新的状态
        /// </summary>
        [ProtoMember(2)]
        public MessageState state;

        /// <summary>
        /// 顶点的数目   即 obj的 所有 v 的集合
        /// </summary>
        [ProtoBuf.ProtoMember(3)]
        public List<_Vector3> vertices = new List<_Vector3>();

        /// <summary>
        /// 法线的数目
        /// </summary>
        [ProtoMember(4)]
        public List<_Vector3> normals = new List<_Vector3>();

        /// <summary>
        /// UV的数目
        /// </summary>
        [ProtoMember(5)]
        public List<_Vector2> uvs = new List<_Vector2>();

        /// <summary>
        /// 对象名
        /// </summary>
        [ProtoBuf.ProtoMember(6)]
        public string name;

        /// <summary>
        /// 材质名
        /// </summary>
        [ProtoBuf.ProtoMember(7)]
        public string materialName;

        /// <summary>
        /// 三角面相关索引数据集合
        /// </summary>
        [ProtoBuf.ProtoMember(8)]
        public List<FaceIndices> faces = new List<FaceIndices>();

        /// <summary>
        /// 三角面相关索引数据集合
        /// </summary>
        [ProtoBuf.ProtoMember(9)]
        public VBOType vboType = VBOType.Null;
    }
}
