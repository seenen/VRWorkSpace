using LibVRGeometry;

namespace VRClient
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

            UpdateData();
        }

        public RobotArm(HDRobotArmMessage ram)
        {
            mHDRobotArmMessage = ram;

            UpdateData();
        }

        void UpdateData()
        {
            //  肩部位置
            mShoulderPos = new _Vector3(mHDRobotArmMessage.mOriginPos.X,
                                        mHDRobotArmMessage.mOriginPos.Y + mHDRobotArmMessage.mShoulderHeight,
                                        mHDRobotArmMessage.mOriginPos.Z);

            ElbowPos();
        }

        /// <summary>
        /// 绕Y旋转
        /// </summary>
        void ElbowPos()
        {
            double x = (double)mHDRobotArmMessage.mUpperarmLen;
            double y = (double)mHDRobotArmMessage.mShoulderHeight;
            double z = (double)0;

            double x_new =  z * System.Math.Sin(MathUtil.ConvertToRadians((double)mHDRobotArmMessage.mFaceAngle)) + 
                            x * System.Math.Cos(MathUtil.ConvertToRadians((double)mHDRobotArmMessage.mFaceAngle));
            double y_new =  y;
            double z_new =  z * System.Math.Cos(MathUtil.ConvertToRadians((double)mHDRobotArmMessage.mFaceAngle)) -
                            x * System.Math.Sin(MathUtil.ConvertToRadians((double)mHDRobotArmMessage.mFaceAngle));

            //  肘部位置
            mElbowPos = new _Vector3((float)x_new, (float)y_new, (float)z_new);

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

            UpdateData();

            return true;
        }
    }
}
