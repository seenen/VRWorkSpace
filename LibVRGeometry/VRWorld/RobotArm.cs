using LibVRGeometry;
using LibVRGeometry.Util;

namespace LibVRGeometry.VRWorld
{
    /// <summary>
    /// 机械手臂
    /// </summary>
    public class RobotArm
    {
        int mId = -1;

        //  肩部位置
        _Vector3 mShoulderPos;

        //  肘部位置
        _Vector3 mElbowPos;

        //  手位置
        _Vector3 mHandlerPos;

        //  工具长度
        float mToolLength;

        //  工具头部
        _Vector3 mToolHead = new _Vector3(0, 0, 0);

        //  工具尾部
        _Vector3 mToolTail = new _Vector3(0, 0, 0);

        HDRobotArmMessage mHDRobotArmMessage;

        /// <summary>
        /// 机械臂的
        /// </summary>
        /// <param name="ShoulderHeight">肩高</param>
        /// <param name="UpperarmLen">上臂长度</param>
        /// <param name="ForearmLen">前臂长度</param>
        public RobotArm()
        {
            mHDRobotArmMessage.mElbowAngle = 0;
            mHDRobotArmMessage.mFaceAngle = 0;

            mHDRobotArmMessage.mOriginPos = new _Vector3(0, 0, 0);
            mShoulderPos = new _Vector3(0, 0, 0);
            mElbowPos = new _Vector3(0, 0, 0);
            mHandlerPos = new _Vector3(0, 0, 0);
        }

        public RobotArm(int id, _Vector3 origin, float ShoulderHeight, float UpperarmLen, float ForearmLen)
        {
            mId = id;

            mHDRobotArmMessage.mElbowAngle = 0;
            mHDRobotArmMessage.mFaceAngle = 0;

            mHDRobotArmMessage.mOriginPos = origin;
            mHDRobotArmMessage.mShoulderHeight = ShoulderHeight;
            mHDRobotArmMessage.mUpperarmLen = UpperarmLen;
            mHDRobotArmMessage.mForearmLen = ForearmLen;
        }

        public RobotArm(HDRobotArmMessage ram)
        {
            mId = ram.id;

            mHDRobotArmMessage = ram;
        }

        /// <summary>
        /// 更新工具位置
        /// </summary>
        /// <param name="toollen">工具总长</param>
        /// <param name="upperpartlen">工具到顶部位置</param>
        public void UpdateTool(float toollen, float upperpartlen)
        {
            if (toollen < upperpartlen)
                throw new System.Exception("toollen < upperpartlen");

            //  求弧度
            double A1 = MathUtil.ConvertToRadians((double)mHDRobotArmMessage.mFaceAngle);
            double A2 = MathUtil.ConvertToRadians((double)mHDRobotArmMessage.mElbowAngle);

            double P2_x = mHDRobotArmMessage.mUpperarmLen + mHDRobotArmMessage.mForearmLen * System.Math.Cos(A2) +
                            (toollen - upperpartlen) * System.Math.Sin(A2);
            double P2_y = mHDRobotArmMessage.mUpperarmLen + mHDRobotArmMessage.mForearmLen * System.Math.Sin(A2) -
                            (toollen - upperpartlen) * System.Math.Cos(A2);

            //  P2_x就是距离基座的距离

            mToolHead.X = (float)(P2_x * System.Math.Cos(A1));
            mToolHead.Y = (float)P2_y;
            mToolHead.Z = -(float)(P2_x * System.Math.Sin(A1));

            return;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="angle"></param>
        public bool Fresh(HDRobotArmMessage ram)
        {
            if (mId != ram.id)
                return false;

            mHDRobotArmMessage = ram;

            return true;
        }
    }
}
