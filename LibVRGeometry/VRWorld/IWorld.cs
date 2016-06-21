using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibVRGeometry.VRWorld
{
    public interface IWorld
    {
        HDTitaniumClampMessage tc { get; }

        HDScissorsMessage sm { get;}

        bool UpdateLRobotArm(ref HDRobotArmMessage msg, float Len);

        bool UpdateRRobotArm(HDRobotArmMessage msg, float Len);

        bool AddMessage(IMessage_U2C msg);
    }
}
