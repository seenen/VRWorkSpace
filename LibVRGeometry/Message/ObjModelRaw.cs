using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibVRGeometry
{

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
        public MessageState state;

        [ProtoMember(4)]
        public int t = 0;

    }
}
