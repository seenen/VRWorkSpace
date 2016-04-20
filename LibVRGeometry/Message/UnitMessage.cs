using ProtoBuf;

namespace LibVRGeometry.Message
{
    /// <summary>
    /// 单位信息.
    /// </summary>
    [ProtoContract]
    public class UnitMessage
    {
        /// <summary>
        /// ID
        /// </summary>
        [ProtoMember(1)]
        public int id;
    }
}
