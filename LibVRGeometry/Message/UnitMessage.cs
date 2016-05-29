using ProtoBuf;

namespace LibVRGeometry
{
    /// <summary>
    /// 单位信息.
    /// </summary>
    [ProtoContract]
    [ProtoInclude(3, typeof(HDMessage))]
    public class UnitMessage
    {
        /// <summary>
        /// ID
        /// </summary>
        [ProtoMember(1)]
        public int id;

        /// <summary>
        /// ID
        /// </summary>
        [ProtoMember(2)]
        public UnitMessageState state;
    }
}
