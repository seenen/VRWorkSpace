using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibVRGeometry.VRWorld
{
    public interface IWorld
    {
        bool UpdateLRobotArm(HDRobotArmMessage msg, float Len);

        bool UpdateRRobotArm(HDRobotArmMessage msg, float Len);

    }
}
