using ProtoBuf;
using System;
using System.Collections.Generic;

namespace LibVRGeometry
{
    [Serializable]
    [ProtoContract]
    public class ObjModel
    {
        [ProtoMember(1)]
        public List<_Vector3> positionList = new List<_Vector3>();

        [ProtoMember(2)]
        public List<_Vector2> uvList = new List<_Vector2>();

        [ProtoMember(3)]
        public List<_Vector3> normalList = new List<_Vector3>();

        [ProtoMember(4)]
        public List<Tuple> faceList = new List<Tuple>();

        [NonSerialized]
        internal List<Triangle> innerFaceList = new List<Triangle>();

    }

}
