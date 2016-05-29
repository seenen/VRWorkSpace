using System;
using LibVRGeometry;
using LibVRGeometry.Message;

namespace VRClient
{
    public class MessageInstance : IMessage
    {
        public void OnMD2HO(IM_MD2HO o)
        {
            throw new NotImplementedException();
        }

        public void OnMDScissors(HDScissorsMessage o)
        {
            throw new NotImplementedException();
        }

        void IMessage.OnEditorMessage(EditorMessage buffer)
        {
            throw new NotImplementedException();
        }

        void IMessage.OnMDTitaniumClamp(HDTitaniumClampMessage o)
        {
            throw new NotImplementedException();
        }

        void IMessage.OnSceneMessage(SceneMessage o)
        {
            throw new NotImplementedException();
        }

        void IMessage.OnVBOBuffer(VBOBuffer buffer)
        {
            throw new NotImplementedException();
        }

        void IMessage.OnVBOBufferSingle(VBOBufferSingle buffer)
        {
            throw new NotImplementedException();
        }
    }
}
