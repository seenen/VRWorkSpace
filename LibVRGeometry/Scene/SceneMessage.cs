using ProtoBuf;

namespace LibVRGeometry.Message
{
    /// <summary>
    /// 场景信息
    /// </summary>
    [ProtoContract]
    public class SceneMessage
    {
        [ProtoMember(1)]
        public string scene_name = string.Empty;
    } 
}
