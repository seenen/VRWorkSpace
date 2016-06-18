using ProtoBuf;

namespace LibVRGeometry.Message
{
    /// <summary>
    /// 场景信息
    /// </summary>
    [ProtoContract]
    public class EnvCfg
    {
        [ProtoMember(1)]
        public string Log = "-";
    } 
}
