using ProtoBuf;

namespace LibVRGeometry.Message
{
    /// <summary>
    /// 单位信息.
    /// </summary>
    [ProtoContract]
    public class UnitMessage
    {
        [ProtoMember(1)]
        public int id;

        /// <summary>
        /// 三个自由度的旋转.默认初始化是向下的
        /// </summary>
        [ProtoMember(2)]
        public _Vector3 eularAngle;

        /// <summary>
        /// 三个空间方向.
        /// </summary>
        [ProtoMember(3)]
        public _Vector3 position;
    }
}
