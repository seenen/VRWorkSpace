using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibVRGeometry
{
    /// <summary>
    /// 剪刀
    /// </summary>
    [Serializable]
    [ProtoContract]
    public class HDRobotArmMessage : HDMessage
    {
        /// <summary>
        /// 水平夹角 A1
        /// 朝向(正为顺时针，负为逆时针)夹角
        /// </summary>
        [ProtoMember(1)]
        public float mFaceAngle = 0;

        /// <summary>
        /// 垂直夹角A2
        /// 前臂和上臂(正为向上旋转，负为向下旋转)的夹角
        /// </summary>
        [ProtoMember(2)]
        public float mElbowAngle = 0;

        /// <summary>
        /// 肩高(米)
        /// </summary>
        [ProtoMember(3)]
        public float mShoulderHeight = 0;

        /// <summary>
        /// 上臂长度(米)
        /// </summary>
        [ProtoMember(4)]
        public float mUpperarmLen = 0;

        /// <summary>
        /// 前臂长度(米)
        /// </summary>
        [ProtoMember(5)]
        public float mForearmLen = 0;

        /// <summary>
        /// 机械臂坐标原点
        /// </summary>
        [ProtoMember(6)]
        public _Vector3 mOriginPos = new _Vector3(0, 0, 0);


        /// <summary>
        /// 器材头部位置
        /// </summary>
        [ProtoMember(7)]
        public _Vector3 mToolHead = new _Vector3(0, 0, 0);


        /// <summary>
        /// 机械臂和器材连接点
        /// </summary>
        [ProtoMember(8)]
        public _Vector3 mToolKey = new _Vector3(0, 0, 0);

        /// <summary>
        /// 机械臂肘部位置
        /// </summary>
        [ProtoMember(9)]
        public _Vector3 mToolElbow = new _Vector3(0, 0, 0);

        
    }
}
