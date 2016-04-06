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

        internal List<Triangle> innerFaceList = new List<Triangle>();

    }

    [Serializable]
    public enum ObjModelRawState
    {
        Null,

        Create,

        Update,

        Destory,
    }

    [Serializable]
    public class ObjModelRaw
    {
        //  模型id
        public int id = -1;

        //  模型内容
        public string content;

        //  状态
        public ObjModelRawState state = ObjModelRawState.Null;
    }
}
