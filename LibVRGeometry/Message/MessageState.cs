using ProtoBuf;
using System;

namespace LibVRGeometry
{
    [Serializable]
    [Flags]
    public enum MessageState
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
}
