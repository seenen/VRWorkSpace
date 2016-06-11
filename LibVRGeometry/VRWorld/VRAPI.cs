using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibVRGeometry.VRWorld
{
    sealed public class VRAPI
    {
        static IWorld mIWorld;

        static VRAPI()
        {
        }

        public static void SetU3DHandler(IWorld worldhandler)
        {
            mIWorld = worldhandler;
        }

        #region 左边操作API

        /// <summary>
        /// 给左边机械手绑定器械
        /// </summary>
        /// <param name="hdmsg"></param>
        public static bool UpdateLeftRobotArm(ref HDRobotArmMessage armmsg, float Len)
        {
            return mIWorld.UpdateLRobotArm(ref armmsg, Len);
        }

        #endregion

        #region 右边操作API
        /// <summary>
        /// 给右边机械手绑定器械
        /// </summary>
        /// <param name="hdmsg"></param>
        public static bool UpdateRightRobotArm(HDRobotArmMessage armmsg, float Len)
        {
            return mIWorld.UpdateRRobotArm(armmsg, Len);

        }
        #endregion
    }
}
