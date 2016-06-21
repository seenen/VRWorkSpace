using System;
using LibVRGeometry;
using LibVRGeometry.VRWorld;
using VRClient;
using System.Collections.Generic;

namespace LibVRGeometry.VRWorld
{
    public class WorldMgr : IWorld
    {
        private Unity3dControl unity3dControl2;

        public WorldMgr(Unity3dControl u)
        {
            unity3dControl2 = u;

            CreateTitanium();

            CreateScissor();
        }

        /// <summary>
        /// 创建一个钳子
        /// </summary>
        void CreateTitanium()
        {
            _tc = new HDTitaniumClampMessage();
            _tc.type = HDType.TitaniumClamp;
            _tc.id = 0;
            _tc.state = UnitMessageState.Create;
            _tc.left = new HDComponentMessage();
            _tc.left.interactiveComName = "NoBlade";
            _tc.left.id = 1;

            _tc.right = new HDComponentMessage();
            _tc.right.interactiveComName = "Blade";
            _tc.right.id = 2;

            this.unity3dControl2.SendMessage<HDTitaniumClampMessage>(tc);
        }

        /// <summary>
        /// 创建一个剪子
        /// </summary>
        void CreateScissor()
        {
            _sm = new HDScissorsMessage();
            _sm.type = HDType.Scissors;
            _sm.state = UnitMessageState.Create;
            _sm.id = 1;
            _sm.left = new HDComponentMessage();
            _sm.left.id = 1;
            _sm.left.interactiveComName = "Blade (2)";

            _sm.right = new HDComponentMessage();
            _sm.right.id = 2;
            _sm.right.interactiveComName = "Blade (3)";

            this.unity3dControl2.SendMessage<HDScissorsMessage>(sm);
        }

        HDTitaniumClampMessage _tc;
        public HDTitaniumClampMessage tc
        {
            get { return _tc; }
        }


        HDScissorsMessage _sm;
        public HDScissorsMessage sm
        {
            get { return _sm; }
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


        List<IMessage_U2C> listMsg = new List<IMessage_U2C>();

        /// <summary>
        /// 添加消息的监听
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool AddMessage(IMessage_U2C msg)
        {
            listMsg.Add(msg);

            return true;
        }

        /// <summary>
        /// 向注册的对象发送消息
        /// </summary>
        /// <param name="o"></param>
        internal protected void OnMD2HO(IM_MD2HO o)
        {
            foreach (IMessage_U2C m in listMsg)
            {
                m.OnMD2HO(o);
            }
        }
    }
}
