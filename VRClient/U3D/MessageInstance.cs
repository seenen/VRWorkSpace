using System;
using LibVRGeometry;
using LibVRGeometry.Message;
using LibVRGeometry.VRWorld;

namespace VRClient
{
    public class MessageInstance : IMessage
    {
        WorldMgr mWorldMgr = null;

        public MessageInstance(WorldMgr mgr)
        {
            mWorldMgr = mgr;
        }

        void IMessage_U2C.OnMD2HO(IM_MD2HO o)
        {
            mWorldMgr.OnMD2HO(o);
        }

        public void OnMDScissors(HDScissorsMessage o)
        {
            throw new NotImplementedException();
        }

        void IMessage_C2U.OnEditorMessage(EditorMessage buffer)
        {
            throw new NotImplementedException();
        }

        void IMessage_C2U.OnMDTitaniumClamp(HDTitaniumClampMessage o)
        {
            throw new NotImplementedException();
        }

        void IMessage_C2U.OnMDRobotArm(HDRobotArmMessage o)
        {
            throw new NotImplementedException();
        }

        void IMessage_C2U.OnSceneMessage(SceneMessage o)
        {
            throw new NotImplementedException();
        }

        void IMessage_C2U.OnVBOBuffer(VBOBuffer buffer)
        {
            throw new NotImplementedException();
        }

        void IMessage_C2U.OnVBOBufferSingle(VBOBufferSingle buffer)
        {
            throw new NotImplementedException();
        }

        public void OnEnvCfg(EnvCfg o)
        {
            throw new NotImplementedException();
        }

        public void OnAddMessage(HDScissorsMessage sm, HDTitaniumClampMessage tc)
        {
            throw new NotImplementedException();
        }
    }
}
