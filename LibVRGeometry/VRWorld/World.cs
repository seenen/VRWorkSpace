using LibVRGeometry;

namespace LibVRGeometry.VRWorld
{
    public class VRWorld
    {
        RobotArm mRobotArm;

        public VRWorld()
        {
            //  初始化一个机械手臂
            mRobotArm = new RobotArm(   100, 
                                        new _Vector3(0, 0, 0), 
                                        50,
                                        50,
                                        80);

        }
    }
}
