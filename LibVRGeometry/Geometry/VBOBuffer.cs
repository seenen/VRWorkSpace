using ProtoBuf;
using System;
using System.Collections.Generic;

namespace LibVRGeometry
{

    /// <summary>
    /// 网格交互数据 这里的数据格式是根据一个标准的 .obj得来
    /// </summary>
    [Serializable]
    [ProtoContract]
    public class VBOBuffer
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
        public VBOState state;

        /// <summary>
        /// 顶点的数目   即 obj的 所有 v 的集合
        /// </summary>
        [ProtoMember(3)]
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
        /// VBO里对象的数目
        /// </summary>
        [ProtoBuf.ProtoMember(6)]
        public List<ObjectData> objects = new List<ObjectData>();

        /// <summary>
        /// 三角索引的数目 即 obj的 所有 v 的集合
        /// </summary>
        [ProtoMember(7)]
        public List<int> triangles = new List<int>();

        /// <summary>
        /// 当前消息的时间戳 
        /// C#: System.DateTime.Now.Millisecond
        /// </summary>
        [ProtoMember(8)]
        public int TimeStamp = 0;

        


    }
}
