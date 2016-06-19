using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibVRGeometry
{
    /// <summary>
    /// 器械的组件属性
    /// </summary>
    [ProtoContract]
    public class HDComponentMessage : UnitMessage
    {
        /// <summary>
        /// 所属的器材的ID
        /// </summary>
        [ProtoMember(1)]
        public int MD_ID;

        /// <summary>
        /// 交互属性
        /// </summary>
        [ProtoMember(2)]
        public InteractiveType it = InteractiveType.Null;

        /// <summary>
        /// 是否碰撞
        /// </summary>
        [ProtoMember(3)]
        public bool IsCollision;

        /// <summary>
        /// 碰撞位置
        /// </summary>
        [ProtoMember(4)]
        public _Vector3 CollisionPos;

        /// <summary>
        /// 当前组件绑定的物体对象
        /// </summary>
        [ProtoMember(5)]
        public string objName;
    }
}
