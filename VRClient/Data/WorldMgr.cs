using LibVRGeometry;
using LibVRGeometry.VRWorld;
using VRClient;

namespace LibVRGeometry.VRWorld
{
    public class WorldMgr : IWorld
    {
        private Unity3dControl unity3dControl2;

        public WorldMgr(Unity3dControl u)
        {
            unity3dControl2 = u;
        }

        RobotArm mLRobotArm;
        HDRobotArmMessage mLHDRobotArmMessage;
        RobotArm mRRobotArm;
        HDRobotArmMessage mRHDRobotArmMessage;

        public bool UpdateLRobotArm(ref HDRobotArmMessage msg, float Len)
        {
            if (msg == null)
                return false;

            mLHDRobotArmMessage = msg;

            if (mLRobotArm == null)
            {
                mLRobotArm = new RobotArm(msg);
            }

            mLRobotArm.Fresh(msg);

            mLRobotArm.UpdateTool(msg.length, Len);

            this.unity3dControl2.SendMessage<HDRobotArmMessage>(msg);

            msg = mLHDRobotArmMessage;

            return true;
        }

        public bool UpdateRRobotArm(HDRobotArmMessage msg, float Len)
        {
            if (msg == null)
                return false;

            mRHDRobotArmMessage = msg;

            if (mRRobotArm == null)
            {
                mRRobotArm = new RobotArm(mRHDRobotArmMessage);
            }
            else
            {
                mRRobotArm.Fresh(mRHDRobotArmMessage);

                mRRobotArm.UpdateTool(mRHDRobotArmMessage.length, Len);
            }

            return true;

        }
    }
}
