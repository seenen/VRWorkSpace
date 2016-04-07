using LibraryGeometryFormat;
using ProtoBuf;
using System;
using System.Collections.Generic;

namespace LibraryGeometryFormat
{
    [Serializable]
    public class ObjModel
    {
        public List<_Vector3> positionList = new List<_Vector3>();

        public List<_Vector2> uvList = new List<_Vector2>();

        public List<_Vector3> normalList = new List<_Vector3>();

        public List<Tuple> faceList = new List<Tuple>();

        [NonSerialized]
        internal List<Triangle> innerFaceList = new List<Triangle>();

    }

    [Serializable]
    [Flags]
    public enum ObjModelRawState
    {
        [ProtoMember(1)]
        Null,

        [ProtoMember(2)]
        Create,

        [ProtoMember(3)]
        Update,

        [ProtoMember(4)]
        Destory,
    }

    [Serializable]
    [ProtoContract]
    public class ObjModelRaw
    {
        //  模型id
        [ProtoBuf.ProtoMember(1)]
        public int id { get; set; }

        //  模型内容
        [ProtoBuf.ProtoMember(2)]
        public string content { get; set; }

        //  状态
        [ProtoMember(3)]
        public ObjModelRawState state;

        [ProtoMember(4)]
        public int t = 0;

    }

    ////[Serializable]
    ////[ProtoContract]
    ////public class FaceIndices
    ////{
    ////    [ProtoBuf.ProtoMember(1)]
    ////    public int vi;

    ////    [ProtoBuf.ProtoMember(2)]
    ////    public int vu;

    ////    [ProtoBuf.ProtoMember(3)]
    ////    public int vn;
    ////}
}
